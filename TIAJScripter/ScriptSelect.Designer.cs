namespace TIAJScripter
{
    partial class ScriptSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                tiaThread.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scriptFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.portalBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.projectTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptFileBox = new System.Windows.Forms.GroupBox();
            this.FileTable = new System.Windows.Forms.TableLayoutPanel();
            this.scriptFileEntry = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.bottomButtonBox = new System.Windows.Forms.FlowLayoutPanel();
            this.run_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.GroupBox();
            this.consoleText = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.portalBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.scriptFileBox.SuspendLayout();
            this.FileTable.SuspendLayout();
            this.bottomButtonBox.SuspendLayout();
            this.logBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.portalBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 485);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // portalBox
            // 
            this.portalBox.AutoSize = true;
            this.portalBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.portalBox.Controls.Add(this.tableLayoutPanel2);
            this.portalBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portalBox.Location = new System.Drawing.Point(0, 0);
            this.portalBox.Name = "portalBox";
            this.portalBox.Size = new System.Drawing.Size(266, 485);
            this.portalBox.TabIndex = 3;
            this.portalBox.TabStop = false;
            this.portalBox.Text = "TIA Portal";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.projectTreeView, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 466);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Controls.Add(this.btn_connect);
            this.flowLayoutPanel1.Controls.Add(this.btn_disconnect);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 434);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(3, 3);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(100, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(109, 3);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(100, 23);
            this.btn_disconnect.TabIndex = 1;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // projectTreeView
            // 
            this.projectTreeView.CheckBoxes = true;
            this.projectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTreeView.Location = new System.Drawing.Point(3, 3);
            this.projectTreeView.Name = "projectTreeView";
            this.projectTreeView.Size = new System.Drawing.Size(254, 425);
            this.projectTreeView.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.scriptFileBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bottomButtonBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.logBox, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 485);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // scriptFileBox
            // 
            this.scriptFileBox.AutoSize = true;
            this.scriptFileBox.Controls.Add(this.FileTable);
            this.scriptFileBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptFileBox.Location = new System.Drawing.Point(3, 0);
            this.scriptFileBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.scriptFileBox.Name = "scriptFileBox";
            this.scriptFileBox.Size = new System.Drawing.Size(524, 45);
            this.scriptFileBox.TabIndex = 2;
            this.scriptFileBox.TabStop = false;
            this.scriptFileBox.Text = "Script file";
            // 
            // FileTable
            // 
            this.FileTable.AutoSize = true;
            this.FileTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileTable.ColumnCount = 2;
            this.FileTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.87259F));
            this.FileTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.12741F));
            this.FileTable.Controls.Add(this.scriptFileEntry, 0, 0);
            this.FileTable.Controls.Add(this.browse_button, 1, 0);
            this.FileTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.FileTable.Location = new System.Drawing.Point(3, 16);
            this.FileTable.Name = "FileTable";
            this.FileTable.RowCount = 1;
            this.FileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FileTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.FileTable.Size = new System.Drawing.Size(518, 26);
            this.FileTable.TabIndex = 0;
            // 
            // scriptFileEntry
            // 
            this.scriptFileEntry.AllowDrop = true;
            this.scriptFileEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptFileEntry.Location = new System.Drawing.Point(3, 3);
            this.scriptFileEntry.Name = "scriptFileEntry";
            this.scriptFileEntry.Size = new System.Drawing.Size(444, 20);
            this.scriptFileEntry.TabIndex = 0;
            this.scriptFileEntry.DragDrop += new System.Windows.Forms.DragEventHandler(this.ScriptFileEntry_DragDrop);
            this.scriptFileEntry.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScriptFileEntry_DragEnter);
            // 
            // browse_button
            // 
            this.browse_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.browse_button.Location = new System.Drawing.Point(453, 3);
            this.browse_button.MinimumSize = new System.Drawing.Size(50, 0);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(62, 20);
            this.browse_button.TabIndex = 1;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // bottomButtonBox
            // 
            this.bottomButtonBox.Controls.Add(this.run_button);
            this.bottomButtonBox.Controls.Add(this.stop_button);
            this.bottomButtonBox.Controls.Add(this.clear_button);
            this.bottomButtonBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.bottomButtonBox.Location = new System.Drawing.Point(3, 48);
            this.bottomButtonBox.Name = "bottomButtonBox";
            this.bottomButtonBox.Size = new System.Drawing.Size(524, 38);
            this.bottomButtonBox.TabIndex = 1;
            // 
            // run_button
            // 
            this.run_button.AllowDrop = true;
            this.run_button.Location = new System.Drawing.Point(3, 3);
            this.run_button.Name = "run_button";
            this.run_button.Size = new System.Drawing.Size(75, 23);
            this.run_button.TabIndex = 0;
            this.run_button.Text = "Run";
            this.run_button.UseVisualStyleBackColor = true;
            this.run_button.Click += new System.EventHandler(this.ButtonRun_Click);
            this.run_button.DragDrop += new System.Windows.Forms.DragEventHandler(this.ButtonRun_DragDrop);
            this.run_button.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScriptFileEntry_DragEnter);
            // 
            // stop_button
            // 
            this.stop_button.Location = new System.Drawing.Point(84, 3);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(75, 23);
            this.stop_button.TabIndex = 2;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = true;
            this.stop_button.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(165, 3);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(107, 23);
            this.clear_button.TabIndex = 1;
            this.clear_button.Text = "Clear output";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // logBox
            // 
            this.logBox.AutoSize = true;
            this.logBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logBox.Controls.Add(this.consoleText);
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(3, 92);
            this.logBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(524, 393);
            this.logBox.TabIndex = 3;
            this.logBox.TabStop = false;
            this.logBox.Text = "Output";
            // 
            // consoleText
            // 
            this.consoleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.consoleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleText.Location = new System.Drawing.Point(3, 16);
            this.consoleText.Name = "consoleText";
            this.consoleText.ReadOnly = true;
            this.consoleText.Size = new System.Drawing.Size(518, 374);
            this.consoleText.TabIndex = 2;
            this.consoleText.Text = "";
            // 
            // ScriptSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ScriptSelect";
            this.Text = "Script Select";
            this.Load += new System.EventHandler(this.ScriptSelect_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.portalBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.scriptFileBox.ResumeLayout(false);
            this.scriptFileBox.PerformLayout();
            this.FileTable.ResumeLayout(false);
            this.FileTable.PerformLayout();
            this.bottomButtonBox.ResumeLayout(false);
            this.logBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog scriptFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.TreeView projectTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel FileTable;
        private System.Windows.Forms.TextBox scriptFileEntry;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.FlowLayoutPanel bottomButtonBox;
        private System.Windows.Forms.Button run_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.RichTextBox consoleText;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.GroupBox scriptFileBox;
        private System.Windows.Forms.GroupBox logBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox portalBox;
    }
}