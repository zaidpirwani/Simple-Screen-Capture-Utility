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
        Point p1 = new Point();
        Point p2 = new Point();
        public Form1()
        {
            InitializeComponent();

        }

        private void bt_capture_Click(object sender, EventArgs e)
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

        private void bt_region_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.25D;
            bt_capture.Visible = false;
            bt_region.Visible = false;
            pictureBox1.Visible = false;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                p1 = p2;
                p2 = MousePosition;
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Visible = false;
                Bitmap capture = new Bitmap( Math.Abs(p2.X-p1.X), Math.Abs(p2.Y-p1.Y));
                Graphics scr = Graphics.FromImage(capture);
                using (Graphics gr = Graphics.FromImage(capture))
                {
                    gr.CopyFromScreen(new Point(p1.X, p1.Y), Point.Empty, new System.Drawing.Size(Math.Abs(p2.X-p1.X), Math.Abs(p2.Y-p1.Y)));
                }
                pictureBox1.Image = capture;
                this.Opacity = 1.0D;
                bt_capture.Visible = true;
                bt_region.Visible = true;
                pictureBox1.Visible = true;
                this.Visible = true;
            }


        }

    }
}
