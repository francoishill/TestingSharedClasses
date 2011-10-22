namespace TestingSharedClasses
{
	partial class NetworkingInteropForm
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
			this.buttonServer = new System.Windows.Forms.Button();
			this.buttonClient = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonServer
			// 
			this.buttonServer.Location = new System.Drawing.Point(13, 13);
			this.buttonServer.Name = "buttonServer";
			this.buttonServer.Size = new System.Drawing.Size(75, 23);
			this.buttonServer.TabIndex = 0;
			this.buttonServer.Text = "&Start server";
			this.buttonServer.UseVisualStyleBackColor = true;
			this.buttonServer.Click += new System.EventHandler(this.buttonServer_Click);
			// 
			// buttonClient
			// 
			this.buttonClient.Location = new System.Drawing.Point(13, 42);
			this.buttonClient.Name = "buttonClient";
			this.buttonClient.Size = new System.Drawing.Size(140, 23);
			this.buttonClient.TabIndex = 1;
			this.buttonClient.Text = "&Client (send file to server)";
			this.buttonClient.UseVisualStyleBackColor = true;
			this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
									| System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 80);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(382, 259);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 367);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(406, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
			this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// NetworkingInteropForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(406, 389);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.buttonClient);
			this.Controls.Add(this.buttonServer);
			this.Name = "NetworkingInteropForm";
			this.Text = "NetworkingInteropForm";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonServer;
		private System.Windows.Forms.Button buttonClient;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
	}
}

