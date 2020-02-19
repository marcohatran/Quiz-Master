using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem.Controller;
using TracNghiem.Model;

namespace TracNghiem.View {
    public partial class fImportSubject : Form {

        public fImportSubject() {
            InitializeComponent();

            LoadSubject();
        }

        #region Methods

        void LoadSubject() {
            cbbSubject.DataSource = SubjectModel.Instance.getSubjectlist();
            cbbSubject.DisplayMember = "Name";
        }

        #endregion

        #region Events

        private void btnBrowse_Click(object sender, EventArgs e) {
            using (
                OpenFileDialog opfdBrowseExcel = new OpenFileDialog() {
                    Title = "Duyệt tìm file dữ liệu Excel",
                    RestoreDirectory = true,
                    Filter = "Excel Files | *.xlsx; *.xls",
                    ValidateNames = true,
                    Multiselect = false,
                    FilterIndex = 1,
                    CheckFileExists = true,
                    CheckPathExists = true,
                }) {
                if (opfdBrowseExcel.ShowDialog() != DialogResult.OK)
                    return;

                txbPath.Text = opfdBrowseExcel.FileName;

                dtgvQuesList.DataSource = DataTransferOLEDB.Instance.GetExcelData(opfdBrowseExcel.FileName, null, cbbSheets);
            }
        }

        private void btnViewSheet_Click(object sender, EventArgs e) {
            if (txbPath.Text == "" || txbPath.Text == null || cbbSheets.SelectedItem == null) {
                MessageBox.Show("Bạn phải chọn một Tệp tin/Trang mà bạn muốn xem");
                return;
            }
             
            dtgvQuesList.DataSource = DataTransferOLEDB.Instance.GetExcelData(txbPath.Text, cbbSheets.SelectedItem.ToString(), null);

            if (!QuestionModel.Instance.CheckColumnsName(dtgvQuesList)) {
                MessageBox.Show("Tệp tin/Trang bạn đã chọn không có dạng chuẩn của câu hỏi.\nHãy chọn Tệp tin/Trang khác đúng chuẩn để nhập dữ liệu mới!", "Cảnh báo!");
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e) {
            if (!QuestionModel.Instance.CheckColumnsName(dtgvQuesList)) {
                MessageBox.Show("Tệp tin/Trang bạn đã chọn không có dạng chuẩn của câu hỏi.\nHãy chọn Tệp tin/Trang khác đúng chuẩn để nhập dữ liệu mới!", "Cảnh báo!");
                return;
            }
            if (txbPath.Text == "" || txbPath.Text == null || cbbSheets.SelectedItem == null) {
                MessageBox.Show("Bạn phải chọn một Tệp tin/Trang mà bạn muốn nhập dữ liệu vào", "Cảnh báo");
                return;
            }
            
            string subjectName = cbbSubject.Text;

            int SucceedRow = QuestionModel.Instance.ImportDataFromDataTable(subjectName, dtgvQuesList.DataSource as DataTable);

            MessageBox.Show("Đã nhập thành công dữ liệu của " + SucceedRow + " Câu hỏi!", "Thông báo");

            LoadSubject();

            if (importDataEvent != null)
                importDataEvent(this, new EventArgs());
        }

        private void btnDone_Click(object sender, EventArgs e) {
            this.Close();
        }

        private event EventHandler importDataEvent;
        public event EventHandler ImportDataEvent {
            add {
                importDataEvent += value;
            }
            remove {
                importDataEvent -= value;
            }
        }

        #endregion
    }
}
