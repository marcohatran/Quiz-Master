namespace TracNghiem.View {
    partial class fImportSubject {
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
            this.cbbSheets = new System.Windows.Forms.ComboBox();
            this.btnViewSheet = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvQuesList = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.cbbSubject = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuesList)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbSheets);
            this.panel1.Controls.Add(this.btnViewSheet);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txbPath);
            this.panel1.Location = new System.Drawing.Point(601, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 104);
            this.panel1.TabIndex = 0;
            // 
            // cbbSheets
            // 
            this.cbbSheets.FormattingEnabled = true;
            this.cbbSheets.Location = new System.Drawing.Point(123, 60);
            this.cbbSheets.Name = "cbbSheets";
            this.cbbSheets.Size = new System.Drawing.Size(289, 33);
            this.cbbSheets.TabIndex = 8;
            // 
            // btnViewSheet
            // 
            this.btnViewSheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSheet.Location = new System.Drawing.Point(418, 57);
            this.btnViewSheet.Name = "btnViewSheet";
            this.btnViewSheet.Size = new System.Drawing.Size(109, 38);
            this.btnViewSheet.TabIndex = 7;
            this.btnViewSheet.Text = "Xem";
            this.btnViewSheet.UseVisualStyleBackColor = true;
            this.btnViewSheet.Click += new System.EventHandler(this.btnViewSheet_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Tên trang:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Đường dẫn:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(418, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(109, 38);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Duyệt...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txbPath
            // 
            this.txbPath.Location = new System.Drawing.Point(123, 12);
            this.txbPath.Name = "txbPath";
            this.txbPath.Size = new System.Drawing.Size(289, 30);
            this.txbPath.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên môn học:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvQuesList);
            this.panel2.Location = new System.Drawing.Point(13, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1239, 625);
            this.panel2.TabIndex = 10;
            // 
            // dtgvQuesList
            // 
            this.dtgvQuesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvQuesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvQuesList.Location = new System.Drawing.Point(4, 4);
            this.dtgvQuesList.Name = "dtgvQuesList";
            this.dtgvQuesList.RowTemplate.Height = 24;
            this.dtgvQuesList.Size = new System.Drawing.Size(1232, 618);
            this.dtgvQuesList.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cbbSubject);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Location = new System.Drawing.Point(12, 17);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(465, 104);
            this.panel9.TabIndex = 11;
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Location = new System.Drawing.Point(483, 17);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(112, 104);
            this.btnAddSubject.TabIndex = 12;
            this.btnAddSubject.Text = "Thêm môn học";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            this.btnAddSubject.Click += new System.EventHandler(this.btnAddSubject_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(1159, 27);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(93, 85);
            this.btnDone.TabIndex = 13;
            this.btnDone.Text = "Kết thúc";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cbbSubject
            // 
            this.cbbSubject.FormattingEnabled = true;
            this.cbbSubject.Location = new System.Drawing.Point(3, 54);
            this.cbbSubject.Name = "cbbSubject";
            this.cbbSubject.Size = new System.Drawing.Size(459, 33);
            this.cbbSubject.TabIndex = 5;
            // 
            // fImportSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 759);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fImportSubject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập dữ liệu Môn học";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuesList)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvQuesList;
        private System.Windows.Forms.Button btnViewSheet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cbbSheets;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ComboBox cbbSubject;
    }
}