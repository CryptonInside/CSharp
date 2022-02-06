using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnsafeProject
{
    unsafe public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 10;
            int* point = &index;
            listBox1.Items.Add("Значение по указанному адресу: " + *point);
            listBox1.Items.Add("Адрес: " + (int)point);
            point++;
            listBox1.Items.Add("Значение по указанному адресу: " + *point);
            listBox1.Items.Add("Адрес: " + (int)point);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Point p = new Point();
            Point* ptr = &p;
            ptr->X = 10;
            ptr->Y = 20;
            listBox1.Items.Add("Значение X: " + ptr->X);
            listBox1.Items.Add("Значение Y: " + ptr->Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] managedarray = { 10, 20, 5, 2, 54, 9 };
            int* array = stackalloc int[managedarray.Length];
            for (int i = 0; i < managedarray.Length; i++)
            {
                array[i] = managedarray[i];
                listBox1.Items.Add("Значение: " + array[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] array = { 10, 20, 5, 2, 54, 9 };
            fixed(int* arr_ptr = &array[0])
            {
                for (int i = 0; i < array.Length; i++)
                    listBox1.Items.Add("Значение: " + arr_ptr[i]);
            }
        }
    }
}
