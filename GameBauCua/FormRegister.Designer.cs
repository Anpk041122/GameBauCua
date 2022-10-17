
namespace GameBauCua
{
    partial class frmResgister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResgister));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gpRegister = new System.Windows.Forms.GroupBox();
            this.btPrevious = new System.Windows.Forms.Button();
            this.btnSumit = new System.Windows.Forms.Button();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GameBauCua.Properties.Resources._123213;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1878, 949);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gpRegister
            // 
            this.gpRegister.BackColor = System.Drawing.Color.Maroon;
            this.gpRegister.Controls.Add(this.btPrevious);
            this.gpRegister.Controls.Add(this.btnSumit);
            this.gpRegister.Controls.Add(this.txtPasswordConfirm);
            this.gpRegister.Controls.Add(this.txtPassword);
            this.gpRegister.Controls.Add(this.label4);
            this.gpRegister.Controls.Add(this.txtName);
            this.gpRegister.Controls.Add(this.label3);
            this.gpRegister.Controls.Add(this.label2);
            this.gpRegister.Controls.Add(this.label1);
            this.gpRegister.Location = new System.Drawing.Point(41, 40);
            this.gpRegister.Name = "gpRegister";
            this.gpRegister.Size = new System.Drawing.Size(899, 571);
            this.gpRegister.TabIndex = 2;
            this.gpRegister.TabStop = false;
            // 
            // btPrevious
            // 
            this.btPrevious.BackColor = System.Drawing.Color.Yellow;
            this.btPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrevious.Font = new System.Drawing.Font("Magneto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrevious.ForeColor = System.Drawing.Color.Maroon;
            this.btPrevious.Location = new System.Drawing.Point(634, 458);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(229, 59);
            this.btPrevious.TabIndex = 5;
            this.btPrevious.Text = "ĐĂNG NHẬP";
            this.btPrevious.UseVisualStyleBackColor = false;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // btnSumit
            // 
            this.btnSumit.BackColor = System.Drawing.Color.Yellow;
            this.btnSumit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSumit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumit.Font = new System.Drawing.Font("Magneto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSumit.ForeColor = System.Drawing.Color.Maroon;
            this.btnSumit.Location = new System.Drawing.Point(321, 458);
            this.btnSumit.Name = "btnSumit";
            this.btnSumit.Size = new System.Drawing.Size(293, 59);
            this.btnSumit.TabIndex = 4;
            this.btnSumit.Text = "ĐĂNG KÝ NGAY";
            this.btnSumit.UseVisualStyleBackColor = false;
            this.btnSumit.Click += new System.EventHandler(this.btnSumit_Click);
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordConfirm.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPasswordConfirm.Location = new System.Drawing.Point(321, 382);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(542, 34);
            this.txtPasswordConfirm.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPassword.Location = new System.Drawing.Point(321, 302);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(542, 34);
            this.txtPassword.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Magneto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(37, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại mật khẩu : ";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtName.Location = new System.Drawing.Point(321, 219);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(542, 34);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Magneto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(37, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 34);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu : ";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Magneto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(107, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(644, 88);
            this.label2.TabIndex = 0;
            this.label2.Text = "ĐĂNG KÝ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Magneto", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(37, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập : ";
            // 
            // frmResgister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1878, 949);
            this.Controls.Add(this.gpRegister);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1900, 1000);
            this.MinimumSize = new System.Drawing.Size(1900, 1000);
            this.Name = "frmResgister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormRegister";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmResgister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpRegister.ResumeLayout(false);
            this.gpRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gpRegister;
        private System.Windows.Forms.Button btnSumit;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrevious;
    }
}