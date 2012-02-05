namespace TestingSharedClasses
{
	partial class PermanentNetworkConnection
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
			this.buttonStartServer = new System.Windows.Forms.Button();
			this.buttonStartClient = new System.Windows.Forms.Button();
			this.textBoxServerMessages = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.textBoxClientMessages = new System.Windows.Forms.TextBox();
			this.comboBoxServerIP = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonStartServer
			// 
			this.buttonStartServer.Location = new System.Drawing.Point(3, 3);
			this.buttonStartServer.Name = "buttonStartServer";
			this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
			this.buttonStartServer.TabIndex = 0;
			this.buttonStartServer.Text = "Start &Server";
			this.buttonStartServer.UseVisualStyleBackColor = true;
			this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
			// 
			// buttonStartClient
			// 
			this.buttonStartClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStartClient.Location = new System.Drawing.Point(268, 3);
			this.buttonStartClient.Name = "buttonStartClient";
			this.buttonStartClient.Size = new System.Drawing.Size(75, 23);
			this.buttonStartClient.TabIndex = 1;
			this.buttonStartClient.Text = "Send &byte";
			this.buttonStartClient.UseVisualStyleBackColor = true;
			this.buttonStartClient.Click += new System.EventHandler(this.buttonStartClient_Click);
			// 
			// textBoxServerMessages
			// 
			this.textBoxServerMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxServerMessages.Location = new System.Drawing.Point(3, 32);
			this.textBoxServerMessages.Multiline = true;
			this.textBoxServerMessages.Name = "textBoxServerMessages";
			this.textBoxServerMessages.Size = new System.Drawing.Size(320, 257);
			this.textBoxServerMessages.TabIndex = 2;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textBoxServerMessages);
			this.splitContainer1.Panel1.Controls.Add(this.buttonStartServer);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxServerIP);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxClientMessages);
			this.splitContainer1.Panel2.Controls.Add(this.buttonStartClient);
			this.splitContainer1.Size = new System.Drawing.Size(676, 292);
			this.splitContainer1.SplitterDistance = 326;
			this.splitContainer1.TabIndex = 3;
			// 
			// textBoxClientMessages
			// 
			this.textBoxClientMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxClientMessages.Location = new System.Drawing.Point(3, 32);
			this.textBoxClientMessages.Multiline = true;
			this.textBoxClientMessages.Name = "textBoxClientMessages";
			this.textBoxClientMessages.Size = new System.Drawing.Size(340, 257);
			this.textBoxClientMessages.TabIndex = 3;
			// 
			// comboBoxServerIP
			// 
			this.comboBoxServerIP.FormattingEnabled = true;
			this.comboBoxServerIP.Location = new System.Drawing.Point(178, 5);
			this.comboBoxServerIP.Name = "comboBoxServerIP";
			this.comboBoxServerIP.Size = new System.Drawing.Size(84, 21);
			this.comboBoxServerIP.TabIndex = 4;
			this.comboBoxServerIP.Text = "10.0.0.11";
			// 
			// PermanentNetworkConnection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 292);
			this.Controls.Add(this.splitContainer1);
			this.Name = "PermanentNetworkConnection";
			this.Text = "PermanentNetworkConnection";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonStartServer;
		private System.Windows.Forms.Button buttonStartClient;
		private System.Windows.Forms.TextBox textBoxServerMessages;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox textBoxClientMessages;
		private System.Windows.Forms.ComboBox comboBoxServerIP;
	}
}