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
			this.dynamicCodeInvokingUserControl1 = new SharedClasses.DynamicCodeInvokingUserControl();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(101, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Test usercontrol";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dynamicCodeInvokingUserControl1
			// 
			this.dynamicCodeInvokingUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dynamicCodeInvokingUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dynamicCodeInvokingUserControl1.Location = new System.Drawing.Point(3, 40);
			this.dynamicCodeInvokingUserControl1.Name = "dynamicCodeInvokingUserControl1";
			this.dynamicCodeInvokingUserControl1.Padding = new System.Windows.Forms.Padding(3);
			this.dynamicCodeInvokingUserControl1.Size = new System.Drawing.Size(1042, 438);
			this.dynamicCodeInvokingUserControl1.TabIndex = 0;
			// 
			// TestDynamicCodeInvokingUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1048, 481);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dynamicCodeInvokingUserControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TestDynamicCodeInvokingUserControl";
			this.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TestDynamicCodeInvokingUserControl";
			this.ResumeLayout(false);

		}

		#endregion

		private SharedClasses.DynamicCodeInvokingUserControl dynamicCodeInvokingUserControl1;
		private System.Windows.Forms.Button button1;

	}
}