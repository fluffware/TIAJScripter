using Siemens.Engineering;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.HmiUnified;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;
using OpenessExt;

namespace TIAJScripter
{
    public partial class ScriptSelect : Form
    {
        protected TIAAsyncWrapper tiaThread;
        protected ScriptExecuter executer = null;
        protected TiaPortal tiaPortal = null;
        protected TIATree.TreeNodeBuilder builder;
        public ScriptSelect()
        {
            InitializeComponent();
            btn_disconnect.Enabled = false;
            stop_button.Enabled = false;
            // Project tree
            AutoExpandMaxChildren = -1;

            tiaThread = new TIAAsyncWrapper();
            
        }
        protected override void OnClosed(EventArgs e)
        {
            tiaThread.Stop();
            base.OnClosed(e);
        }

        static bool ProjectDescend(object obj)
        {
            return obj is Project || obj is DeviceUserGroup || obj is Device || obj is DeviceItem;

        }

        static bool ProjectLeaf(object obj)
        {
            if (!(obj is DeviceItem)) return false;
            SoftwareContainer sw_cont = ((DeviceItem)obj).GetService<SoftwareContainer>();
            return sw_cont != null;
        }

        // Updates all child tree nodes recursively.
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;

                // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                this.CheckAllChildNodes(node, nodeChecked);

            }
        }

        // After a tree node's Checked property is changed, all its child nodes are updated to the same value.
        private void NodeAfterCheck(object sender, TreeViewEventArgs e)
        {
            // The code only executes if the user caused the checked state to change.
            if (e.Action != TreeViewAction.Unknown)
            {
                /* Calls the CheckAllChildNodes method, passing in the current 
                Checked value of the TreeNode whose checked state changed. */
                this.CheckAllChildNodes(e.Node, e.Node.Checked);

            }
        }

        protected void PortalConnected()
        {
            builder = new TIATree.TreeNodeBuilder(tiaThread, tiaPortal);
            builder.BuildDone += TreeDone;
            builder.Descend = ProjectDescend;
            builder.Leaf = ProjectLeaf;

            projectTreeView.Nodes.Clear();
            projectTreeView.AfterCheck += NodeAfterCheck;
            builder.StartBuild(projectTreeView.Nodes);

        }

        protected void PortalDisconnected()
        {
            builder.CancelBuild();
            projectTreeView.Nodes.Clear();
            builder = null;
        }



        public TIATree.Filter Descend
        {
            get { return builder.Descend; }
            set { builder.Descend = value; }
        }

        public TIATree.Filter Leaf
        {
            get { return builder.Leaf; }
            set { builder.Leaf = value; }
        }


        public int AutoExpandMaxChildren { get; set; }



        protected void TreeDone(object sender, TIATree.BuildDoneEventArgs e)
        {
            if (AutoExpandMaxChildren > 0)
            {
                TIATree.TreeNodeBuilder.Expand(projectTreeView.Nodes, AutoExpandMaxChildren);
            }

        }


        public Object SelectedObject { get; protected set; }

        private void BlockTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = projectTreeView.SelectedNode;
            if (Leaf(node.Tag))
            {
                SelectedObject = node.Tag;
            }
            else
            {

            }
        }

        protected void FormClosingEventHandler(object sender, FormClosingEventArgs e)
        {
            TIATree.TreeNodeBuilder b = builder;
            if (b != null)
            {
                b.CancelBuild();
            }
        }
        PortalSelect select_dialog = null;
        private void ConnectTIA(object sender, EventArgs e)
        {



            if (select_dialog == null)
            {
                select_dialog = new PortalSelect(tiaThread);
            }
            if (select_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TiaPortalProcess proc = select_dialog.selectedProcess();
                if (proc != null)
                {
                    WaitConnect wait = new WaitConnect();
                    wait.Show();
                    Application.DoEvents();
                    try
                    {
                        tiaPortal = (TiaPortal)tiaThread.RunSync((_) => { return proc.Attach(); }, null);
                       
                        btn_connect.Enabled = false;
                       
                        btn_disconnect.Enabled = true;
                        PortalConnected();
                    }
                    catch (EngineeringException ex)
                    {
                        MessageBox.Show("Failed to connect to TIAPortal: " + ex.Message);
                    }
                    wait.Hide();
                    wait.Dispose();

                }
            }


        }

        private void DisconnectTia(object sender, EventArgs e)
        {
            if (tiaPortal != null)
            {
                PortalDisconnected();
                tiaPortal.Dispose();
                tiaPortal = null;
                btn_connect.Enabled = true;
                btn_disconnect.Enabled = false;

            }

        }

        private void ScriptSelect_Load(object sender, EventArgs e)
        {

        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            if (tiaPortal != null && tiaPortal.Projects.Count == 1)
            {
                scriptFileDialog.InitialDirectory = Path.Combine(tiaPortal.Projects[0].Path.DirectoryName, "UserFiles","Scripts");
            }
            
            scriptFileDialog.ShowDialog();
            scriptFileEntry.Text = scriptFileDialog.FileName;
        }

        private class Console : ScriptExecuter.Console
        {

            readonly RichTextBox text_box;
            public Console(RichTextBox text_box)
            {
                this.text_box = text_box;
            }

            public override void Error(string message)
            {
                text_box.SelectionColor = Color.DarkRed;
                text_box.SelectedText = "\n"+message+"\n\n";
                text_box.ScrollToCaret();
            }

            public override void Print(string message)
            {
                text_box.SelectionColor = Color.Black;
                text_box.SelectedText = message + "\n";
                text_box.ScrollToCaret();
            }
        }
        

        private static void FindPlcs(TreeNodeCollection nodes, ref List<PlcSoftware> plcs)
        {
            foreach (TreeNode n in nodes)
            {
                FindPlcs(n.Nodes, ref plcs);
                if (!n.Checked) continue;
                if (!(n.Tag is DeviceItem)) continue;
                SoftwareContainer sw_cont = ((DeviceItem)n.Tag).GetService<SoftwareContainer>();

                if (sw_cont != null)
                {
                    if (sw_cont.Software is PlcSoftware controller)
                    {
                        plcs.Add(controller);

                    }

                }

            }

        }

        private static void FindHmis(TreeNodeCollection nodes, ref List<HmiTarget> hmis)
        {
            foreach (TreeNode n in nodes)
            {
                FindHmis(n.Nodes, ref hmis);
                if (!n.Checked) continue;
                if (!(n.Tag is DeviceItem)) continue;
                SoftwareContainer sw_cont = ((DeviceItem)n.Tag).GetService<SoftwareContainer>();

                if (sw_cont != null)
                {
                    if (sw_cont.Software is HmiTarget hmi_target)
                    {
                        hmis.Add(hmi_target);
                    }
                }
            }
        }

        private static void FindUnifiedHmis(TreeNodeCollection nodes, ref List<HmiSoftware> hmis)
        {
            foreach (TreeNode n in nodes)
            {
                FindUnifiedHmis(n.Nodes, ref hmis);
                if (!n.Checked) continue;
                if (!(n.Tag is DeviceItem)) continue;
                SoftwareContainer sw_cont = ((DeviceItem)n.Tag).GetService<SoftwareContainer>();
                if (sw_cont != null)
                {
                    if (sw_cont.Software is HmiSoftware hmi_sw)
                    {
                        hmis.Add(hmi_sw);
                    }
                }
            }
        }
       

        private void run_button_Click(object sender, EventArgs e)
        {
            try
            {
                var plcs = new List<PlcSoftware>();
                var unified_hmis = new List<HmiSoftware>();
                var hmis = new List<HmiTarget>();
                FindPlcs(projectTreeView.Nodes, ref plcs);
                FindHmis(projectTreeView.Nodes, ref hmis);
                FindUnifiedHmis(projectTreeView.Nodes, ref unified_hmis);
                ScriptExecuter.TIA_Info info = new ScriptExecuter.TIA_Info
                {
                    Portal = tiaPortal,
                    SelectedPlcs = plcs.ToArray(),
                    SelectedUnifiedHmis = unified_hmis.ToArray(),
                    SelectedHmis = hmis.ToArray(),
                    Enum = new EnumLookup()
                };
                Console console = new Console(consoleText);

                executer = new ScriptExecuter(scriptFileEntry.Text, info,console);
                executer.Finished += ScriptFinished;
                tiaThread.RunAsync(executer);
                run_button.Enabled = false;
                stop_button.Enabled = true;
            }
            catch (EngineeringTargetInvocationException ex)
            {
                consoleText.SelectionColor = Color.DarkRed;
                consoleText.SelectedText = "TIA failure:\n"+ex.ToString() + "\n\n";
                consoleText.ScrollToCaret();
            }
            catch (Exception ex)
            {
                consoleText.SelectionColor = Color.DarkRed;
                consoleText.SelectedText = "Failed to execute script:\n"+ex.ToString()+"\n\n";
                consoleText.ScrollToCaret();
            }
        }
        private void stop_button_Click(object sender, EventArgs e)
        {
            executer?.Abort();
        }

        private void ScriptFinished()
        {
            stop_button.Enabled = false;
            run_button.Enabled = true;
            executer = null;
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            consoleText.Clear();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            ConnectTIA(sender, e);
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            DisconnectTia(sender, e);
        }

        private void scriptFileEntry_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void scriptFileEntry_DragDrop(object sender, DragEventArgs e)
        {
            var drop = e.Data.GetData(DataFormats.FileDrop);
            if (drop is string[] paths)
            {
                if (paths.Count() == 1)
                {
                    scriptFileEntry.Text = paths[0];
                }
            }

        }

        private void run_button_DragDrop(object sender, DragEventArgs e)
        {
            scriptFileEntry_DragDrop(sender, e);
            run_button_Click(sender, null);
        }
    }
}
