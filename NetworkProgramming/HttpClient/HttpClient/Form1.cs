using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request;
            try
            {
                request = HttpWebRequest.Create("http://www.flenov.info");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder pagebuilder = new StringBuilder();

                string line;
                while ((line = reader.ReadLine()) != null)
                    pagebuilder.AppendLine(line);

                response.Close();
                reader.Close();
                pageRichTextBox.Text = pagebuilder.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Не могу загрузить файл");
                return;
            }
        }
    }
}
