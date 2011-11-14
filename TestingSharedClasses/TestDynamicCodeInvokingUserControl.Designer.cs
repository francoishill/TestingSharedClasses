namespace TestingSharedClasses
{
	partial class TestDynamicCodeInvokingUserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDynamicCodeInvokingUserControl));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dynamicCodeInvokingUserControl1 = new SharedClasses.DynamicCodeInvokingUserControl();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(139, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Send selected method";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(546, 9);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Send block of code";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dynamicCodeInvokingUserControl1
			// 
			this.dynamicCodeInvokingUserControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dynamicCodeInvokingUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dynamicCodeInvokingUserControl1.Location = new System.Drawing.Point(6, 38);
			this.dynamicCodeInvokingUserControl1.Name = "dynamicCodeInvokingUserControl1";
			this.dynamicCodeInvokingUserControl1.Padding = new System.Windows.Forms.Padding(3);
			this.dynamicCodeInvokingUserControl1.Size = new System.Drawing.Size(985, 437);
			this.dynamicCodeInvokingUserControl1.TabIndex = 2;
			// 
			// TestDynamicCodeInvokingUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 481);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dynamicCodeInvokingUserControl1);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TestDynamicCodeInvokingUserControl";
			this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TestDynamicCodeInvokingUserControl";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private SharedClasses.DynamicCodeInvokingUserControl dynamicCodeInvokingUserControl1;
		private System.Windows.Forms.Button button2;

	}
}