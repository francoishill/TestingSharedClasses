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
			// TestXmlRpc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.button_XmlRpcServer);
			this.Controls.Add(this.button_XmlRpcClient);
			this.Name = "TestXmlRpc";
			this.Text = "TestXmlRpc";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestXmlRpc_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button_XmlRpcClient;
		private System.Windows.Forms.Button button_XmlRpcServer;
	}
}