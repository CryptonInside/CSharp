using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UriTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Uri uri = new Uri(urlTextBox.Text);
            string query = uri.Query.Substring(1, uri.Query.Length - 1);
            string[] parameters = query.Split('&');

            foreach (string segment in parameters)
            {
                string[] paramvalues = segment.Split('=');
                listBox1.Items.Add("Param: " + paramvalues[0]);
                if (paramvalues.Length > 1)
                    listBox1.Items.Add("Value: " + paramvalues[1]);
            }
        }
    }
}
