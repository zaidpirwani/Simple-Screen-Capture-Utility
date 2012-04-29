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
        Point origin = new Point();
        Rectangle rect = new Rectangle();
        Rectangle line1 = new Rectangle();
        Rectangle line2 = new Rectangle();
        Boolean capture_mode = new Boolean();
        Boolean tray_mode = new Boolean();

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

                    if (tray_mode == false)
                    {
                        this.Opacity = 1.0D;
                        this.Visible = true;
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.Fixed3D;

                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        linkLabel1.Visible = true;
                    }

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
            button2.Visible = false;
            button3.Visible = false;
            linkLabel1.Visible = false;
            capture_mode = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, not yet implemented\nThe image has been put on CLIPBOARD to paste in WORD/Paint/etc","Function not Implemented YET",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (capture_mode)
            {
                line1 = new Rectangle(0, e.Y, Screen.PrimaryScreen.Bounds.Width, 1);
                line2 = new Rectangle(e.X, 0, 1, Screen.PrimaryScreen.Bounds.Height);
                if (e.Button == MouseButtons.Left)
                {
                    if (e.X < origin.X && e.Y > origin.Y)
                        rect = new Rectangle(e.X, origin.Y, origin.X - e.X, e.Y - origin.Y);
                    else if (e.X > origin.X && e.Y < origin.Y)
                        rect = new Rectangle(origin.X, e.Y, e.X - origin.X, origin.Y - e.Y);
                    else if (e.X < origin.X && e.Y < origin.Y)
                        rect = new Rectangle(e.X, e.Y, origin.X - e.X, origin.Y - e.Y);
                    else if (e.X > origin.X && e.Y > origin.Y)
                        rect = new Rectangle(origin.X, origin.Y, e.X - origin.X, e.Y - origin.Y);
                }
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
                origin = new Point(e.X,e.Y);
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
            button2.Visible = false;
            button3.Visible = false;
            linkLabel1.Visible = false;
            tray_mode = true;
            capture_mode = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.ShowBalloonTip(4000, "Simple Screen Capture Utility", "Left Click to Capture Region\nRight Click to Finish\nCaptured Image is READY for PASTING", ToolTipIcon.Info);
            tray_mode = true;            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Opacity = 1.0D;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            linkLabel1.Visible = true;

            line1 = new Rectangle(0, 0, 0, 0);
            line2 = new Rectangle(0, 0, 0, 0);
            rect = new Rectangle(0, 0, 0, 0);

            capture_mode = false;
            tray_mode = false;

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

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Select Capture Region from the Menu\n   OR  Click the PrintScreen Button in the App\n\n2. Left Click and Drag to select a Region.\n\n3. Right Click when the desired region is selected\n    You can try selecting the region as many times as needed.\n\n4. When Right Click is pressed, capture preview is shown and the capture is saved to Clipboard ready to be pasted in your application (Word/Paint/Photoshop/etc)", "User-Guie / How-to", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Opacity = 0.25D;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                linkLabel1.Visible = false;
                tray_mode = true;
                capture_mode = true;
            }
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ZaidPirwani.com/933/");
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("1. Select Capture Region from the Menu\n   OR  Click the PrintScreen Button in the App\n\n2. Left Click and Drag to select a Region.\n\n3. Right Click when the desired region is selected\n    You can try selecting the region as many times as needed.\n\n4. When Right Click is pressed, capture preview is shown and the capture is saved to Clipboard ready to be pasted in your application (Word/Paint/Photoshop/etc)", "User-Guie / How-to", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://ZaidPirwani.com");
        }
    }
}
