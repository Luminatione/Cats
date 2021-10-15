using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Cats
{
	public partial class Form1 : Form
	{

		private String api = "https://catfact.ninja/fact";
		private string currentFact;
		private Thread updateThread;
		public Form1()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadCatFact();
		}

		string GetFactFromJson(JObject json) => json["fact"].ToString();

		private void SetLabelTextToCurrentCat()
		{
			richTextBox1.Text = currentFact;
			GC.Collect();
		}
		private void GetFact()
		{
			WebClient client = new WebClient();
			currentFact = GetFactFromJson(JObject.Parse(client.DownloadString(api)));
			richTextBox1.Invoke((MethodInvoker)SetLabelTextToCurrentCat);
		}

		private void LoadCatFact()
		{
			updateThread = new Thread(GetFact);
			updateThread.Start();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			LoadCatFact();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
