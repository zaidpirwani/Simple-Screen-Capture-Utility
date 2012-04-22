using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs_test
{
    public partial class Form_2 : Form
    {

        public Bitmap prev_image
        {
            set { pictureBox1.Image = value; }
        }

        public Form_2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
