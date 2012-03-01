namespace TestingSharedClasses
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.buttonNetworkingInterop = new System.Windows.Forms.Button();
			this.buttonAutoCompleteInterop = new System.Windows.Forms.Button();
			this.labelRecoveryAndRestartSafe = new System.Windows.Forms.Label();
			this.buttonSerializationInterop = new System.Windows.Forms.Button();
			this.buttonTempNewCommandsManagerClass = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_SettingsInterop = new System.Windows.Forms.Button();
			this.button_XmlRpc = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			//this.inlineCommandsUserControl1 = new SharedClasses.InlineCommandsUserControl();
			this.buttonTestPermanentNetworkConnection = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonNetworkingInterop
			// 
			this.buttonNetworkingInterop.Location = new System.Drawing.Point(13, 13);
			this.buttonNetworkingInterop.Name = "buttonNetworkingInterop";
			this.buttonNetworkingInterop.Size = new System.Drawing.Size(115, 23);
			this.buttonNetworkingInterop.TabIndex = 0;
			this.buttonNetworkingInterop.Text = "&Networking Interop";
			this.buttonNetworkingInterop.UseVisualStyleBackColor = true;
			this.buttonNetworkingInterop.Click += new System.EventHandler(this.buttonNetworkingInterop_Click);
			// 
			// buttonAutoCompleteInterop
			// 
			this.buttonAutoCompleteInterop.Location = new System.Drawing.Point(12, 72);
			this.buttonAutoCompleteInterop.Name = "buttonAutoCompleteInterop";
			this.buttonAutoCompleteInterop.Size = new System.Drawing.Size(133, 23);
			this.buttonAutoCompleteInterop.TabIndex = 1;
			this.buttonAutoCompleteInterop.Text = "&Auto Complete Interop";
			this.buttonAutoCompleteInterop.UseVisualStyleBackColor = true;
			this.buttonAutoCompleteInterop.Click += new System.EventHandler(this.buttonAutoCompleteInterop_Click);
			// 
			// labelRecoveryAndRestartSafe
			// 
			this.labelRecoveryAndRestartSafe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelRecoveryAndRestartSafe.AutoSize = true;
			this.labelRecoveryAndRestartSafe.ForeColor = System.Drawing.Color.Green;
			this.labelRecoveryAndRestartSafe.Location = new System.Drawing.Point(641, 431);
			this.labelRecoveryAndRestartSafe.Name = "labelRecoveryAndRestartSafe";
			this.labelRecoveryAndRestartSafe.Size = new System.Drawing.Size(136, 13);
			this.labelRecoveryAndRestartSafe.TabIndex = 2;
			this.labelRecoveryAndRestartSafe.Text = "Recovery and Restart Safe";
			this.labelRecoveryAndRestartSafe.Visible = false;
			// 
			// buttonSerializationInterop
			// 
			this.buttonSerializationInterop.Location = new System.Drawing.Point(12, 102);
			this.buttonSerializationInterop.Name = "buttonSerializationInterop";
			this.buttonSerializationInterop.Size = new System.Drawing.Size(115, 23);
			this.buttonSerializationInterop.TabIndex = 3;
			this.buttonSerializationInterop.Text = "Serialization Interop";
			this.buttonSerializationInterop.UseVisualStyleBackColor = true;
			this.buttonSerializationInterop.Click += new System.EventHandler(this.buttonSerializationInterop_Click);
			// 
			// buttonTempNewCommandsManagerClass
			// 
			this.buttonTempNewCommandsManagerClass.Location = new System.Drawing.Point(12, 131);
			this.buttonTempNewCommandsManagerClass.Name = "buttonTempNewCommandsManagerClass";
			this.buttonTempNewCommandsManagerClass.Size = new System.Drawing.Size(179, 23);
			this.buttonTempNewCommandsManagerClass.TabIndex = 4;
			this.buttonTempNewCommandsManagerClass.Text = "Temp New Commands Manager";
			this.buttonTempNewCommandsManagerClass.UseVisualStyleBackColor = true;
			this.buttonTempNewCommandsManagerClass.Click += new System.EventHandler(this.buttonTempNewCommandsManagerClass_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox1.Location = new System.Drawing.Point(13, 234);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(469, 182);
			this.textBox1.TabIndex = 5;
			// 
			// button_SettingsInterop
			// 
			this.button_SettingsInterop.Location = new System.Drawing.Point(12, 160);
			this.button_SettingsInterop.Name = "button_SettingsInterop";
			this.button_SettingsInterop.Size = new System.Drawing.Size(115, 23);
			this.button_SettingsInterop.TabIndex = 6;
			this.button_SettingsInterop.Text = "Settings Interop";
			this.button_SettingsInterop.UseVisualStyleBackColor = true;
			this.button_SettingsInterop.Click += new System.EventHandler(this.button_SettingsInterop_Click);
			// 
			// button_XmlRpc
			// 
			this.button_XmlRpc.Location = new System.Drawing.Point(12, 189);
			this.button_XmlRpc.Name = "button_XmlRpc";
			this.button_XmlRpc.Size = new System.Drawing.Size(75, 23);
			this.button_XmlRpc.TabIndex = 7;
			this.button_XmlRpc.Text = "Xml Rpc";
			this.button_XmlRpc.UseVisualStyleBackColor = true;
			this.button_XmlRpc.Click += new System.EventHandler(this.button_XmlRpc_Click);
			// 
			// treeView1
			// 
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(258, 13);
			this.treeView1.Name = "treeView1";
			this.treeView1.ShowLines = false;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(187, 113);
			this.treeView1.TabIndex = 8;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// textBox2
			// 
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(258, 135);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(187, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(532, 73);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(158, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "Inline commands (new)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// inlineCommandsUserControl1
			// 
			/*this.inlineCommandsUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.inlineCommandsUserControl1.Enabled = false;
			this.inlineCommandsUserControl1.Location = new System.Drawing.Point(488, 13);
			this.inlineCommandsUserControl1.Name = "inlineCommandsUserControl1";
			this.inlineCommandsUserControl1.Padding = new System.Windows.Forms.Padding(2);
			this.inlineCommandsUserControl1.Size = new System.Drawing.Size(277, 403);
			this.inlineCommandsUserControl1.TabIndex = 10;*/
			// 
			// buttonTestPermanentNetworkConnection
			// 
			this.buttonTestPermanentNetworkConnection.Location = new System.Drawing.Point(13, 43);
			this.buttonTestPermanentNetworkConnection.Name = "buttonTestPermanentNetworkConnection";
			this.buttonTestPermanentNetworkConnection.Size = new System.Drawing.Size(195, 23);
			this.buttonTestPermanentNetworkConnection.TabIndex = 12;
			this.buttonTestPermanentNetworkConnection.Text = "Test &Permanent Network Connection";
			this.buttonTestPermanentNetworkConnection.UseVisualStyleBackColor = true;
			this.buttonTestPermanentNetworkConnection.Click += new System.EventHandler(this.buttonTestPermanentNetworkConnection_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 445);
			this.Controls.Add(this.buttonTestPermanentNetworkConnection);
			this.Controls.Add(this.button1);
			//this.Controls.Add(this.inlineCommandsUserControl1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.button_XmlRpc);
			this.Controls.Add(this.button_SettingsInterop);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonTempNewCommandsManagerClass);
			this.Controls.Add(this.buttonSerializationInterop);
			this.Controls.Add(this.labelRecoveryAndRestartSafe);
			this.Controls.Add(this.buttonAutoCompleteInterop);
			this.Controls.Add(this.buttonNetworkingInterop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonNetworkingInterop;
		private System.Windows.Forms.Button buttonAutoCompleteInterop;
		private System.Windows.Forms.Label labelRecoveryAndRestartSafe;
		private System.Windows.Forms.Button buttonSerializationInterop;
		private System.Windows.Forms.Button buttonTempNewCommandsManagerClass;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button_SettingsInterop;
		private System.Windows.Forms.Button button_XmlRpc;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox textBox2;
		//private SharedClasses.InlineCommandsUserControl inlineCommandsUserControl1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonTestPermanentNetworkConnection;
	}
}