using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            textBox2.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //password of the password
            if (textBox1.Text == "Bryce")
            {
                textBox2.Show();
            }

            else
            {
                textBox2.Hide();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
//final password
            if (textBox2.Text == "Hi Bryce =)")
            {
                //this is from my AI or ACS System 
                MessageBox.Show("Welcome Sir to the A.C.S");
                new Form1().Show();
                textBox2.Hide();
            }
        }

    }
}
