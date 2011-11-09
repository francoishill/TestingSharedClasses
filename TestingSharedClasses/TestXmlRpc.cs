using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CookComputing.XmlRpc;

namespace TestingSharedClasses
{
	public partial class TestXmlRpc : Form
	{
		public TestXmlRpc()
		{
			InitializeComponent();
		}

		private void button_XmlRpcServer_Click(object sender, EventArgs e)
		{
			XmlRpcInterop.SampleServer();
		}

		private void button_XmlRpcClient_Click(object sender, EventArgs e)
		{
			XmlRpcInterop.SampleClient();
		}

		private void TestXmlRpc_FormClosing(object sender, FormClosingEventArgs e)
		{
			XmlRpcInterop.UnregisterAllRegisteredChannels();
		}

		//TextFeedbackEventHandler textFeedback;
		private void button_TestTracXmlRpc_Click(object sender, EventArgs e)
		{
			ObtainTicketStatusses();
		}

		private void ObtainTicketStatusses()
		{
			button_TestTracXmlRpc.Enabled = false;
			//textFeedback += (snder, evtargs) =>
			//{
			//	MessageBox.Show(evtargs.FeedbackText);
			//};
			//VisualStudioInterop.TestTracXmlRpc(textFeedback);

			string url = TracXmlRpcInterop.MonitorSystemXmlRpcUrl;

			dataGridView_ChangeLog.Columns.Clear();
			foreach (FieldInfo fieldInfo in typeof(TracXmlRpcInterop.ChangeLogStruct).GetFields())
				dataGridView_ChangeLog.Columns.Add(fieldInfo.Name, fieldInfo.Name);

			dataGridView_Tickets.Columns.Clear();
			List<string> fieldLabels = null;
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{ fieldLabels = TracXmlRpcInterop.GetFieldLables(url); },
				ThreadName: "TracXmlRpcInterop GetFieldLabels");
			foreach (string fieldlabel in fieldLabels)
				dataGridView_Tickets.Columns.Add(fieldlabel.ToLower(), fieldlabel);

			int[] ticketIdList = new int[0];
			ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
			{ ticketIdList = TracXmlRpcInterop.GetTicketIds(url); },
				ThreadName: "TracXmlRpcInterop GetTicketIds");

			foreach (int ticketID in ticketIdList)
			{
				dataGridView_Tickets.Rows.Add();
				int rowNum = dataGridView_Tickets.Rows.Count - (dataGridView_Tickets.AllowUserToAddRows ? 2 : 1);
				Dictionary<string, object> dict = null;
				ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
				{ dict = TracXmlRpcInterop.GetFieldValuesOfTicket(ticketID, url); },
					ThreadName: "TracXmlRpcInterop GetFieldValuesOfTicket");
				foreach (string key in dict.Keys)
				{
					string tmpColName = key.ToLower();
					int colNum = dataGridView_Tickets.Columns[tmpColName].Index;
					if (!dataGridView_Tickets.Columns.Contains(tmpColName)) continue;
					dataGridView_Tickets[
						colNum,
						rowNum
						].Value = dict[key];
				}
				//List<TracXmlRpcInterop.ChangeLogStruct> cl = TracXmlRpcInterop.ChangeLogs(ticketID);
				//foreach (TracXmlRpcInterop.ChangeLogStruct c in cl)
				//	MessageBox.Show(c.Field);
				ThreadingInterop.PerformVoidFunctionSeperateThread(() =>
				{ dataGridView_Tickets.Rows[rowNum].Tag = TracXmlRpcInterop.ChangeLogs(ticketID, url); },
					ThreadName: "TracXmlRpcInterop ChangeLogs",
					CheckInvokeRequired: true,
					controlToCheckInvokeRequired: this);
			}

			if (dataGridView_Tickets.Rows.Count > 0)
			{
				dataGridView_Tickets.Rows[0].Selected = true;
				PopulateChangeLogGrid(0);
			}
			button_TestTracXmlRpc.Enabled = true;
		}

		private void dataGridView_Tickets_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			PopulateChangeLogGrid(e.RowIndex);
		}

		private void PopulateChangeLogGrid(int rowIndex)
		{
			dataGridView_ChangeLog.Rows.Clear();
			if (rowIndex == -1)
				return;
			if (dataGridView_Tickets.Rows[rowIndex].Tag is List<TracXmlRpcInterop.ChangeLogStruct>)
			{
				List<TracXmlRpcInterop.ChangeLogStruct> changes = dataGridView_Tickets.Rows[rowIndex].Tag as List<TracXmlRpcInterop.ChangeLogStruct>;
				foreach (TracXmlRpcInterop.ChangeLogStruct change in changes)
				{
					dataGridView_ChangeLog.Rows.Add();
					int rowNum = dataGridView_ChangeLog.Rows.Count - (dataGridView_ChangeLog.AllowUserToAddRows ? 2 : 1);
					foreach (FieldInfo fieldInfo in typeof(TracXmlRpcInterop.ChangeLogStruct).GetFields())
						dataGridView_ChangeLog[
							dataGridView_ChangeLog.Columns[fieldInfo.Name].Index, rowNum].Value =
							fieldInfo.GetValue(change);
				}
			}
		}
	}
}
