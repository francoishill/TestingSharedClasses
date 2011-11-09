namespace TestingSharedClasses
{
	partial class TestXmlRpc
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
			this.button_XmlRpcClient = new System.Windows.Forms.Button();
			this.button_XmlRpcServer = new System.Windows.Forms.Button();
			this.button_TestTracXmlRpc = new System.Windows.Forms.Button();
			this.dataGridView_Tickets = new System.Windows.Forms.DataGridView();
			this.dataGridView_ChangeLog = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tickets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChangeLog)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button_XmlRpcClient
			// 
			this.button_XmlRpcClient.Location = new System.Drawing.Point(12, 41);
			this.button_XmlRpcClient.Name = "button_XmlRpcClient";
			this.button_XmlRpcClient.Size = new System.Drawing.Size(106, 23);
			this.button_XmlRpcClient.TabIndex = 1;
			this.button_XmlRpcClient.Text = "Xml Rpc Client";
			this.button_XmlRpcClient.UseVisualStyleBackColor = true;
			this.button_XmlRpcClient.Click += new System.EventHandler(this.button_XmlRpcClient_Click);
			// 
			// button_XmlRpcServer
			// 
			this.button_XmlRpcServer.Location = new System.Drawing.Point(12, 12);
			this.button_XmlRpcServer.Name = "button_XmlRpcServer";
			this.button_XmlRpcServer.Size = new System.Drawing.Size(106, 23);
			this.button_XmlRpcServer.TabIndex = 2;
			this.button_XmlRpcServer.Text = "Xml Rpc Client";
			this.button_XmlRpcServer.UseVisualStyleBackColor = true;
			this.button_XmlRpcServer.Click += new System.EventHandler(this.button_XmlRpcServer_Click);
			// 
			// button_TestTracXmlRpc
			// 
			this.button_TestTracXmlRpc.Location = new System.Drawing.Point(12, 70);
			this.button_TestTracXmlRpc.Name = "button_TestTracXmlRpc";
			this.button_TestTracXmlRpc.Size = new System.Drawing.Size(106, 23);
			this.button_TestTracXmlRpc.TabIndex = 3;
			this.button_TestTracXmlRpc.Text = "Test Trac XmlRpc";
			this.button_TestTracXmlRpc.UseVisualStyleBackColor = true;
			this.button_TestTracXmlRpc.Click += new System.EventHandler(this.button_TestTracXmlRpc_Click);
			// 
			// dataGridView_Tickets
			// 
			this.dataGridView_Tickets.AllowUserToAddRows = false;
			this.dataGridView_Tickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_Tickets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_Tickets.Location = new System.Drawing.Point(0, 0);
			this.dataGridView_Tickets.Name = "dataGridView_Tickets";
			this.dataGridView_Tickets.Size = new System.Drawing.Size(524, 372);
			this.dataGridView_Tickets.TabIndex = 4;
			this.dataGridView_Tickets.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Tickets_RowEnter);
			// 
			// dataGridView_ChangeLog
			// 
			this.dataGridView_ChangeLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_ChangeLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.ValueColumn});
			this.dataGridView_ChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_ChangeLog.Location = new System.Drawing.Point(0, 0);
			this.dataGridView_ChangeLog.Name = "dataGridView_ChangeLog";
			this.dataGridView_ChangeLog.Size = new System.Drawing.Size(258, 372);
			this.dataGridView_ChangeLog.TabIndex = 5;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(13, 117);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView_Tickets);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView_ChangeLog);
			this.splitContainer1.Size = new System.Drawing.Size(786, 372);
			this.splitContainer1.SplitterDistance = 524;
			this.splitContainer1.TabIndex = 6;
			// 
			// KeyColumn
			// 
			this.KeyColumn.HeaderText = "KeyColumn";
			this.KeyColumn.Name = "KeyColumn";
			// 
			// ValueColumn
			// 
			this.ValueColumn.HeaderText = "ValueColumn";
			this.ValueColumn.Name = "ValueColumn";
			// 
			// TestXmlRpc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 501);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.button_TestTracXmlRpc);
			this.Controls.Add(this.button_XmlRpcServer);
			this.Controls.Add(this.button_XmlRpcClient);
			this.Name = "TestXmlRpc";
			this.Text = "TestXmlRpc";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestXmlRpc_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tickets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChangeLog)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_XmlRpcClient;
		private System.Windows.Forms.Button button_XmlRpcServer;
		private System.Windows.Forms.Button button_TestTracXmlRpc;
		private System.Windows.Forms.DataGridView dataGridView_Tickets;
		private System.Windows.Forms.DataGridView dataGridView_ChangeLog;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
	}
}