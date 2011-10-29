using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TestingSharedClasses
{
	public partial class SerializationInteropForm : Form
	{
		public SerializationInteropForm()
		{
			InitializeComponent();
		}

		//private int ControlCount = 0;
		private void AddControl(Control control)
		{
			//if (ControlCount > 0) tableLayoutPanel1.RowCount++;
			//tableLayoutPanel1.Controls.Add(control, 0, ControlCount);
			//ControlCount++;
			flowLayoutPanel1.Controls.Add(control);
			//tableLayoutPanel1.SetRow(control, ControlCount);
			
		}

		public void AddControlsForCustomObject(object customObject)
		{
			foreach (FieldInfo fieldInfo in customObject.GetType().GetFields())
				if (fieldInfo.IsPublic)
				{
					AddControl(new Label() { Text = fieldInfo.Name + " (" + fieldInfo.FieldType + ")" });
				}
			foreach (PropertyInfo propertyInfo in customObject.GetType().GetProperties())
				if (propertyInfo.CanWrite)
				{
					AddControl(new Label() { Text = propertyInfo.Name + " (" + propertyInfo.PropertyType + ")" });
				}
		}
	}
}
