namespace TracNghiem.View {
    partial class fExamProperty {
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
            this.cbbChooseSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.nmudSecond = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nmudMinute = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nmudHour = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nmudNumQues = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudHour)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudNumQues)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbChooseSubject);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 65);
            this.panel1.TabIndex = 0;
            // 
            // cbbChooseSubject
            // 
            this.cbbChooseSubject.FormattingEnabled = true;
            this.cbbChooseSubject.Location = new System.Drawing.Point(143, 16);
            this.cbbChooseSubject.Name = "cbbChooseSubject";
            this.cbbChooseSubject.Size = new System.Drawing.Size(430, 33);
            this.cbbChooseSubject.TabIndex = 1;
            this.cbbChooseSubject.SelectedIndexChanged += new System.EventHandler(this.cbbChooseSubject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn môn thi:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nmudSecond);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.nmudMinute);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nmudHour);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 65);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giây";
            // 
            // nmudSecond
            // 
            this.nmudSecond.Location = new System.Drawing.Point(428, 17);
            this.nmudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmudSecond.Name = "nmudSecond";
            this.nmudSecond.Size = new System.Drawing.Size(83, 30);
            this.nmudSecond.TabIndex = 5;
            this.nmudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phút";
            // 
            // nmudMinute
            // 
            this.nmudMinute.Location = new System.Drawing.Point(281, 17);
            this.nmudMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmudMinute.Name = "nmudMinute";
            this.nmudMinute.Size = new System.Drawing.Size(83, 30);
            this.nmudMinute.TabIndex = 3;
            this.nmudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmudMinute.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giờ";
            // 
            // nmudHour
            // 
            this.nmudHour.Location = new System.Drawing.Point(144, 17);
            this.nmudHour.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nmudHour.Name = "nmudHour";
            this.nmudHour.Size = new System.Drawing.Size(83, 30);
            this.nmudHour.TabIndex = 1;
            this.nmudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thời gian thi:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(455, 225);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 48);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay Lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(293, 225);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(134, 48);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Làm bài !";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nmudNumQues);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(12, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 65);
            this.panel3.TabIndex = 4;
            // 
            // nmudNumQues
            // 
            this.nmudNumQues.Location = new System.Drawing.Point(220, 17);
            this.nmudNumQues.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nmudNumQues.Name = "nmudNumQues";
            this.nmudNumQues.Size = new System.Drawing.Size(291, 30);
            this.nmudNumQues.TabIndex = 1;
            this.nmudNumQues.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Chọn số lượng câu";
            // 
            // fExamProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 285);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fExamProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thuộc tính bài thi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmudHour)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudNumQues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbChooseSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nmudSecond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmudMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmudHour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nmudNumQues;
        private System.Windows.Forms.Label label9;
    }
}