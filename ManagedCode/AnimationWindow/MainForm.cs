using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnimationWindow
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Win32Iface.MoveWindow(this.Handle, 1, 2, 600, 400, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
