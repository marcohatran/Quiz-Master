namespace TracNghiem.View {
    partial class fAddAccount {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbReEnterPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txbRanking = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.txbPoint = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.nmudCorrectAns = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cbbAccountType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nmudTotalAns = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDoneAddAccount = new System.Windows.Forms.Button();
            this.btnSaveAddAccount = new System.Windows.Forms.Button();
            this.lbExistUserName = new System.Windows.Forms.Label();
            this.lbGuidePass = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudCorrectAns)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudTotalAns)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbUserName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 69);
            this.panel1.TabIndex = 1;
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(235, 19);
            this.txbUserName.MaxLength = 100;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(470, 30);
            this.txbUserName.TabIndex = 1;
            this.txbUserName.TextChanged += new System.EventHandler(this.txbUserName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbDisplayName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(708, 69);
            this.panel3.TabIndex = 3;
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDisplayName.Location = new System.Drawing.Point(235, 19);
            this.txbDisplayName.MaxLength = 500;
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(470, 30);
            this.txbDisplayName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên hiển thị:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbReEnterPass);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 237);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(708, 69);
            this.panel4.TabIndex = 5;
            // 
            // txbReEnterPass
            // 
            this.txbReEnterPass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbReEnterPass.Location = new System.Drawing.Point(235, 19);
            this.txbReEnterPass.MaxLength = 40;
            this.txbReEnterPass.Name = "txbReEnterPass";
            this.txbReEnterPass.Size = new System.Drawing.Size(470, 30);
            this.txbReEnterPass.TabIndex = 4;
            this.txbReEnterPass.UseSystemPasswordChar = true;
            this.txbReEnterPass.Leave += new System.EventHandler(this.txbReEnterPass_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập lại mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbPassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 69);
            this.panel2.TabIndex = 4;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(235, 19);
            this.txbPassword.MaxLength = 40;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(470, 30);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            this.txbPassword.Enter += new System.EventHandler(this.txbPassword_Enter);
            this.txbPassword.Leave += new System.EventHandler(this.txbPassword_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.txbRanking);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel18.Location = new System.Drawing.Point(12, 550);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(708, 69);
            this.panel18.TabIndex = 21;
            // 
            // txbRanking
            // 
            this.txbRanking.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRanking.Location = new System.Drawing.Point(206, 16);
            this.txbRanking.Name = "txbRanking";
            this.txbRanking.ReadOnly = true;
            this.txbRanking.Size = new System.Drawing.Size(499, 34);
            this.txbRanking.TabIndex = 1;
            this.txbRanking.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(178, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "==> Xếp hạng:";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.txbPoint);
            this.panel17.Controls.Add(this.label13);
            this.panel17.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel17.Location = new System.Drawing.Point(12, 475);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(708, 69);
            this.panel17.TabIndex = 20;
            // 
            // txbPoint
            // 
            this.txbPoint.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPoint.Location = new System.Drawing.Point(206, 16);
            this.txbPoint.Name = "txbPoint";
            this.txbPoint.ReadOnly = true;
            this.txbPoint.Size = new System.Drawing.Size(499, 34);
            this.txbPoint.TabIndex = 1;
            this.txbPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 29);
            this.label13.TabIndex = 0;
            this.label13.Text = "==> Điểm:";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.nmudCorrectAns);
            this.panel15.Controls.Add(this.label11);
            this.panel15.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel15.Location = new System.Drawing.Point(92, 387);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(236, 82);
            this.panel15.TabIndex = 19;
            // 
            // nmudCorrectAns
            // 
            this.nmudCorrectAns.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmudCorrectAns.Location = new System.Drawing.Point(21, 38);
            this.nmudCorrectAns.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmudCorrectAns.Name = "nmudCorrectAns";
            this.nmudCorrectAns.Size = new System.Drawing.Size(158, 34);
            this.nmudCorrectAns.TabIndex = 1;
            this.nmudCorrectAns.ValueChanged += new System.EventHandler(this.nmudCorrectAns_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Số câu đúng:";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cbbAccountType);
            this.panel14.Controls.Add(this.label9);
            this.panel14.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel14.Location = new System.Drawing.Point(12, 312);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(708, 69);
            this.panel14.TabIndex = 18;
            // 
            // cbbAccountType
            // 
            this.cbbAccountType.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAccountType.FormattingEnabled = true;
            this.cbbAccountType.Location = new System.Drawing.Point(235, 11);
            this.cbbAccountType.Name = "cbbAccountType";
            this.cbbAccountType.Size = new System.Drawing.Size(470, 35);
            this.cbbAccountType.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "Loại tài khoản:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nmudTotalAns);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(415, 387);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 82);
            this.panel5.TabIndex = 22;
            // 
            // nmudTotalAns
            // 
            this.nmudTotalAns.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmudTotalAns.Location = new System.Drawing.Point(21, 38);
            this.nmudTotalAns.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmudTotalAns.Name = "nmudTotalAns";
            this.nmudTotalAns.Size = new System.Drawing.Size(159, 34);
            this.nmudTotalAns.TabIndex = 1;
            this.nmudTotalAns.ValueChanged += new System.EventHandler(this.nmudTotalAns_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tổng số câu:";
            // 
            // btnDoneAddAccount
            // 
            this.btnDoneAddAccount.Location = new System.Drawing.Point(621, 654);
            this.btnDoneAddAccount.Name = "btnDoneAddAccount";
            this.btnDoneAddAccount.Size = new System.Drawing.Size(99, 38);
            this.btnDoneAddAccount.TabIndex = 25;
            this.btnDoneAddAccount.Text = "Kết thúc";
            this.btnDoneAddAccount.UseVisualStyleBackColor = true;
            this.btnDoneAddAccount.Click += new System.EventHandler(this.btnDoneAddAccount_Click);
            // 
            // btnSaveAddAccount
            // 
            this.btnSaveAddAccount.Location = new System.Drawing.Point(496, 654);
            this.btnSaveAddAccount.Name = "btnSaveAddAccount";
            this.btnSaveAddAccount.Size = new System.Drawing.Size(99, 38);
            this.btnSaveAddAccount.TabIndex = 23;
            this.btnSaveAddAccount.Text = "Lưu";
            this.btnSaveAddAccount.UseVisualStyleBackColor = true;
            this.btnSaveAddAccount.Click += new System.EventHandler(this.btnSaveAddAccount_Click);
            // 
            // lbExistUserName
            // 
            this.lbExistUserName.AutoSize = true;
            this.lbExistUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExistUserName.ForeColor = System.Drawing.Color.Red;
            this.lbExistUserName.Location = new System.Drawing.Point(260, 64);
            this.lbExistUserName.Name = "lbExistUserName";
            this.lbExistUserName.Size = new System.Drawing.Size(205, 24);
            this.lbExistUserName.TabIndex = 47;
            this.lbExistUserName.Text = "Tên tài khoản đã tồn tại";
            // 
            // lbGuidePass
            // 
            this.lbGuidePass.AutoSize = true;
            this.lbGuidePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuidePass.ForeColor = System.Drawing.Color.Gray;
            this.lbGuidePass.Location = new System.Drawing.Point(260, 214);
            this.lbGuidePass.Name = "lbGuidePass";
            this.lbGuidePass.Size = new System.Drawing.Size(251, 24);
            this.lbGuidePass.TabIndex = 48;
            this.lbGuidePass.Text = "Nhập mật khẩu tối đa 40 kí tự";
            // 
            // fAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 704);
            this.Controls.Add(this.lbGuidePass);
            this.Controls.Add(this.lbExistUserName);
            this.Controls.Add(this.btnDoneAddAccount);
            this.Controls.Add(this.btnSaveAddAccount);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel18);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fAddAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm tài khoản mới";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudCorrectAns)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudTotalAns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbReEnterPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox txbRanking;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TextBox txbPoint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.NumericUpDown nmudCorrectAns;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.ComboBox cbbAccountType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nmudTotalAns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDoneAddAccount;
        private System.Windows.Forms.Button btnSaveAddAccount;
        private System.Windows.Forms.Label lbExistUserName;
        private System.Windows.Forms.Label lbGuidePass;
    }
}