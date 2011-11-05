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
			this.buttonNetworkingInterop = new System.Windows.Forms.Button();
			this.buttonAutoCompleteInterop = new System.Windows.Forms.Button();
			this.labelRecoveryAndRestartSafe = new System.Windows.Forms.Label();
			this.buttonSerializationInterop = new System.Windows.Forms.Button();
			this.buttonTempNewCommandsManagerClass = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button_SettingsInterop = new System.Windows.Forms.Button();
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
			this.buttonAutoCompleteInterop.Location = new System.Drawing.Point(13, 43);
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
			this.labelRecoveryAndRestartSafe.Location = new System.Drawing.Point(148, 305);
			this.labelRecoveryAndRestartSafe.Name = "labelRecoveryAndRestartSafe";
			this.labelRecoveryAndRestartSafe.Size = new System.Drawing.Size(136, 13);
			this.labelRecoveryAndRestartSafe.TabIndex = 2;
			this.labelRecoveryAndRestartSafe.Text = "Recovery and Restart Safe";
			this.labelRecoveryAndRestartSafe.Visible = false;
			// 
			// buttonSerializationInterop
			// 
			this.buttonSerializationInterop.Location = new System.Drawing.Point(13, 73);
			this.buttonSerializationInterop.Name = "buttonSerializationInterop";
			this.buttonSerializationInterop.Size = new System.Drawing.Size(115, 23);
			this.buttonSerializationInterop.TabIndex = 3;
			this.buttonSerializationInterop.Text = "Serialization Interop";
			this.buttonSerializationInterop.UseVisualStyleBackColor = true;
			this.buttonSerializationInterop.Click += new System.EventHandler(this.buttonSerializationInterop_Click);
			// 
			// buttonTempNewCommandsManagerClass
			// 
			this.buttonTempNewCommandsManagerClass.Location = new System.Drawing.Point(13, 102);
			this.buttonTempNewCommandsManagerClass.Name = "buttonTempNewCommandsManagerClass";
			this.buttonTempNewCommandsManagerClass.Size = new System.Drawing.Size(179, 23);
			this.buttonTempNewCommandsManagerClass.TabIndex = 4;
			this.buttonTempNewCommandsManagerClass.Text = "Temp New Commands Manager";
			this.buttonTempNewCommandsManagerClass.UseVisualStyleBackColor = true;
			this.buttonTempNewCommandsManagerClass.Click += new System.EventHandler(this.buttonTempNewCommandsManagerClass_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(13, 177);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(259, 113);
			this.textBox1.TabIndex = 5;
			// 
			// button_SettingsInterop
			// 
			this.button_SettingsInterop.Location = new System.Drawing.Point(13, 131);
			this.button_SettingsInterop.Name = "button_SettingsInterop";
			this.button_SettingsInterop.Size = new System.Drawing.Size(115, 23);
			this.button_SettingsInterop.TabIndex = 6;
			this.button_SettingsInterop.Text = "Settings Interop";
			this.button_SettingsInterop.UseVisualStyleBackColor = true;
			this.button_SettingsInterop.Click += new System.EventHandler(this.button_SettingsInterop_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 319);
			this.Controls.Add(this.button_SettingsInterop);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonTempNewCommandsManagerClass);
			this.Controls.Add(this.buttonSerializationInterop);
			this.Controls.Add(this.labelRecoveryAndRestartSafe);
			this.Controls.Add(this.buttonAutoCompleteInterop);
			this.Controls.Add(this.buttonNetworkingInterop);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
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
	}
}