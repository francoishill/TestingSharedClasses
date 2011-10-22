using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TestingSharedClasses
{
	public partial class AutoCompleteInteropForm : Form
	{
		public AutoCompleteInteropForm()
		{
			InitializeComponent();

			AutoCompleteInterop.EnableRichTextboxAutocomplete(richTextBox2,
				AutoCompleteInterop.GetWordlistOfFileContents(File.ReadAllText(@"C:\Users\francois\Documents\Visual Studio 2010\Projects\SharedClasses\AutoCompleteInterop.cs"))
				);

			AutoCompleteInterop.EnableRichTextboxAutocomplete(richTextBox1,
				AutoCompleteInterop.GetWordlistOfFileContents(File.ReadAllText(@"C:\Users\francois\Documents\Visual Studio 2010\Projects\SharedClasses\AutoCompleteInterop.cs"))
				//new string[]
				//{
				//  "Francois",
				//  "Yolande",
				//  "Franco",
				//  "Ferdi",
				//  "Yolly"
				//}
				);
			
		}
	}
}
