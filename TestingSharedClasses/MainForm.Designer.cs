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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.buttonAutoCompleteInterop);
			this.Controls.Add(this.buttonNetworkingInterop);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonNetworkingInterop;
		private System.Windows.Forms.Button buttonAutoCompleteInterop;
	}
}