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
        Rectangle rect = new Rectangle();
        Rectangle line1 = new Rectangle();
        Rectangle line2 = new Rectangle();
        Boolean capture_mode = new Boolean();

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (capture_mode && e.Button == MouseButtons.Right)
            {
                if (rect.Height > 0 && rect.Width > 0)
                {
                    this.Visible = false;

                    Point capt_size = new Point();
                    capt_size.X = rect.Width;
                    capt_size.Y = rect.Height;

                    Bitmap capture = new Bitmap(capt_size.X, capt_size.Y);
                    Graphics scr = Graphics.FromImage(capture);
                    using (Graphics gr = Graphics.FromImage(capture))
                    { gr.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, new System.Drawing.Size(capt_size.X, capt_size.Y)); }

                    Form_2 frm_prev = new Form_2();
                    frm_prev.prev_image = capture;
                    frm_prev.Width = capt_size.X + 40;
                    frm_prev.Height = capt_size.Y + 62;
                    frm_prev.ShowDialog();
                    
                    Clipboard.SetImage(capture);

                    this.Opacity = 1.0D;
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;

                    button1.Visible = true;
                    button3.Visible = true;

                    line1 = new Rectangle(0, 0, 0, 0);
                    line2 = new Rectangle(0, 0, 0, 0);
                    rect = new Rectangle(0, 0, 0, 0);

                    capture_mode = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.25D;
            button1.Visible = false;
            button3.Visible = false;
            capture_mode = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, not yet implemented\nThe image will be put on CLIPBOARD though to paste in WORD/Paint/etc");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture_mode)
            {
                line1 = new Rectangle(0, e.Y, Screen.PrimaryScreen.Bounds.Width, 1);
                line2 = new Rectangle(e.X, 0, 1, Screen.PrimaryScreen.Bounds.Height);
                if(e.Button == MouseButtons.Left)
                    rect = new Rectangle(rect.Left, rect.Top, e.X-rect.Left, e.Y-rect.Top);
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(pen, line1);
                e.Graphics.DrawRectangle(pen, line2);
                e.Graphics.DrawRectangle(pen, rect);
            }
            using (Pen pen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (capture_mode && e.Button == MouseButtons.Left)
            {
                rect = new Rectangle(e.X, e.Y, 1, 1);
                this.Invalidate();
            }
        }

        private void captureRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.25D;
            button1.Visible = false;
            button3.Visible = false;
            capture_mode = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Point capt_size = new Point();
            capt_size.X = Screen.PrimaryScreen.Bounds.Width;
            capt_size.Y = Screen.PrimaryScreen.Bounds.Height;

            Bitmap capture = new Bitmap(capt_size.X, capt_size.Y);
            Graphics scr = Graphics.FromImage(capture);
            using (Graphics gr = Graphics.FromImage(capture))
            { gr.CopyFromScreen(new Point(0, 0), Point.Empty, new System.Drawing.Size(capt_size.X, capt_size.Y)); }

            Clipboard.SetImage(capture);
        }
    }
}
