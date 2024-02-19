using Jint;
using Jint.Native;
using Jint.Runtime;
using Jint.Runtime.Interop;
using OpenessExt;
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HmiUnified;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using TIAJScripter.OpenessExt;

namespace TIAJScripter
{
    public class ScriptExecuter : TIAAsyncWrapper.Task
    {
        public delegate void ScriptFinished();
        public ScriptFinished Finished;
        readonly string script_file;
        readonly TIA_Info tia_info;
        readonly Console console;
        CancellationTokenSource cancel = null;
        public struct TIA_Info
        {
            public TiaPortal Portal;
            public PlcSoftware[] SelectedPlcs;
            public HmiTarget[] SelectedHmis;
            public HmiSoftware[] SelectedUnifiedHmis;
            public EnumLookup Enum;
        }

        public abstract class Console
        {
            public abstract void Print(string message);
            public abstract void Error(string message);

        }
        public ScriptExecuter(string script_file, TIA_Info tia_info, Console console)
        {
            this.script_file = script_file;
            this.tia_info = tia_info;
            this.console = console;
        }
        private void ConsoleLog(object msg)
        {
            SendResult(new ConsoleMessage {type = ConsoleMessageType.Print, message = msg.ToString() });
        }
        private void ConsoleError(object msg)
        {
            SendResult(new ConsoleMessage { type = ConsoleMessageType.Error, message = msg.ToString() });
        }
        private static ITypeConverter TypeConverterFactory(Engine engine)
        {
            return new OpenessExt.ConvertType(new DefaultTypeConverter(engine));
        }
        
        private static XmlNamespaceManager XmlNamespaces(String[] ns_defs)
        {
            NameTable nt = new NameTable();
            var nsm = new XmlNamespaceManager(nt);
            
            foreach (String ns_def in ns_defs)
            {
                var parts = ns_def.Split(new char[] { ':' }, 2);
                nsm.AddNamespace(parts[0], parts[1]);

            }
            return nsm;
        }
        delegate XmlNamespaceManager  XmlNamespacesDelegate(string[] message);
        public override object Run()
        {
            cancel = new CancellationTokenSource(); 
            var options = new Jint.Options();
            options.AddExtensionMethods(typeof(HmiScreenExt));
            options.AddExtensionMethods(typeof(UIBaseExt));
            options.AddExtensionMethods(typeof(DynamizationsExt));
            options.AddExtensionMethods(typeof(TriggerExt));
            options.AddExtensionMethods(typeof(EventHandlerExt));
            options.AddExtensionMethods(typeof(MultilingualTextExt));
            options.AddExtensionMethods(typeof(PlcBlockExt));
          
            options.Strict = true;
            string scriptParent = Path.GetDirectoryName(script_file);
            options.EnableModules(scriptParent);
            options.CancellationToken(cancel.Token);
            options.CatchClrExceptions();
            options.SetTypeConverter(TypeConverterFactory);
            Engine js_engine = new Engine(options);
            js_engine.SetValue("log", new Action<object>(ConsoleLog));
            js_engine.SetValue("XmlNamespaces", (XmlNamespacesDelegate)XmlNamespaces);
            if (tia_info.Portal.Projects.Count >= 1)
            {
                MultilingualTextExt.Project = tia_info.Portal.Projects[0];
            }
            
            
            System.Environment.CurrentDirectory = scriptParent;
            JsValue require(string fileName)
            {
                string absPath = Path.GetFullPath(fileName);
                string jsSource = System.IO.File.ReadAllText(absPath);
                js_engine.Execute("var exports = {};var module = {};");
                js_engine.Evaluate(jsSource);
                var module = js_engine.GetValue("module");
                JsValue res = module.Get("exports");
                if (res.IsUndefined())
                {
                    res = js_engine.GetValue("exports");
                }
                return res;
            }

            js_engine.SetValue("require", new Func<string, JsValue>(require));

            js_engine.SetValue("TIA", tia_info);
            
            StreamReader reader = new StreamReader(script_file);
            string script = reader.ReadToEnd();
            reader.Close();
            try
            {
                js_engine.AddModule(script_file, script);
                js_engine.ImportModule(script_file);
            }
            catch (EngineeringTargetInvocationException ex)
            {
                ConsoleError("TIA failure:\n" + ex.ToString() + "\n\n");
            }
            catch(JavaScriptException ex)
            {
                ConsoleError("JavaScript Exception: " + ex.Message + "\n"+ ex.JavaScriptStackTrace);
            }
            catch (Exception ex)
            {
                ConsoleError("Failed to execute script:\n" + ex.ToString() + "\n\n");
            }

            return null;
        }

        // Called in the SynchronizationContext that called TIAAsyncWrapper.Run
        public override void Done(object result)
        {
            Finished();
        }

        public override void CaughtException(Exception ex)
        {
            if (ex is JavaScriptException jsex) {
                console.Error(jsex.Message + "\n" + jsex.JavaScriptStackTrace);
            }
            //console.Error(ex.ToString());
            Finished();
        }

        public void Abort()
        {
            cancel?.Cancel();
            cancel = null;
        }

        enum ConsoleMessageType
        {
            Print,
            Error
        }
        struct ConsoleMessage
        {
            public ConsoleMessageType type;
            public string message;
        }
        // Called in the SynchronizationContext that called TIAAsyncWrapper.Run as a result of calling SendResult
        public override void Result(object result)
        {
            if (result is ConsoleMessage msg)
            {
                switch (msg.type)
                {
                    case ConsoleMessageType.Print:
                        console.Print(msg.message.ToString());
                        break;
                    case ConsoleMessageType.Error:
                        console.Error(msg.message.ToString());
                        break;
                }
            }
        }
    }
}
