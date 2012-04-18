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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int img_top     = Convert.ToInt16(txtb_top.Text);
            int img_bottom  = Convert.ToInt16(txtb_bottom.Text);
            int img_left    = Convert.ToInt16(txtb_left.Text);
            int img_right   = Convert.ToInt16(txtb_right.Text);

            Bitmap capture = new Bitmap(img_right - img_left, img_bottom - img_top);
            Graphics scr = Graphics.FromImage(capture);
            using (Graphics gr = Graphics.FromImage(capture))
            {
                gr.CopyFromScreen(new Point(img_left, img_top), Point.Empty, new System.Drawing.Size(img_right - img_left, img_bottom - img_top));
            }
            pictureBox1.Image = capture;
        }
    }
}
