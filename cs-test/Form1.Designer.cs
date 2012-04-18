namespace cs_test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_capture = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtb_right = new System.Windows.Forms.TextBox();
            this.txtb_top = new System.Windows.Forms.TextBox();
            this.txtb_bottom = new System.Windows.Forms.TextBox();
            this.txtb_left = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_capture
            // 
            this.bt_capture.Location = new System.Drawing.Point(211, 12);
            this.bt_capture.Name = "bt_capture";
            this.bt_capture.Size = new System.Drawing.Size(61, 45);
            this.bt_capture.TabIndex = 0;
            this.bt_capture.Text = "Capture..!";
            this.bt_capture.UseVisualStyleBackColor = true;
            this.bt_capture.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 200);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtb_right
            // 
            this.txtb_right.Location = new System.Drawing.Point(63, 35);
            this.txtb_right.Name = "txtb_right";
            this.txtb_right.Size = new System.Drawing.Size(40, 20);
            this.txtb_right.TabIndex = 2;
            // 
            // txtb_top
            // 
            this.txtb_top.Location = new System.Drawing.Point(12, 35);
            this.txtb_top.Name = "txtb_top";
            this.txtb_top.Size = new System.Drawing.Size(40, 20);
            this.txtb_top.TabIndex = 2;
            // 
            // txtb_bottom
            // 
            this.txtb_bottom.Location = new System.Drawing.Point(114, 35);
            this.txtb_bottom.Name = "txtb_bottom";
            this.txtb_bottom.Size = new System.Drawing.Size(40, 20);
            this.txtb_bottom.TabIndex = 3;
            // 
            // txtb_left
            // 
            this.txtb_left.Location = new System.Drawing.Point(165, 35);
            this.txtb_left.Name = "txtb_left";
            this.txtb_left.Size = new System.Drawing.Size(40, 20);
            this.txtb_left.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Top";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Right";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bottom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Left";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtb_left);
            this.Controls.Add(this.txtb_bottom);
            this.Controls.Add(this.txtb_top);
            this.Controls.Add(this.txtb_right);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_capture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_capture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtb_right;
        private System.Windows.Forms.TextBox txtb_top;
        private System.Windows.Forms.TextBox txtb_bottom;
        private System.Windows.Forms.TextBox txtb_left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;



    }
}

