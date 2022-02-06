using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // загружаем страничку в браузер
            WebBrowser browser = new WebBrowser();
            browser.Navigate(urlTextBox.Text);
            while (browser.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();

            // получаем все теги <a> и перебираем их
            HtmlElementCollection elementsByTagName =
                 browser.Document.GetElementsByTagName("a");
            foreach (HtmlElement element in elementsByTagName)
            {
                resultListBox.Items.Add(element.GetAttribute("href"));
            }

            foreach (Control c in panel2.Controls)
                c.Dispose();

            panel2.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
    }
}
