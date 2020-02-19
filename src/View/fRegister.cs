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
    public partial class fRegister : Form {
        public fRegister() {
            InitializeComponent();

            lbExistUserName.Hide();

            lbGuidePass.Hide();
        }

        #region Methods

        #endregion

        #region Events

        private void btnDoneRegister_Click(object sender, EventArgs e) {
            string UserName = txbUserName.Text;

            if (AccountModel.Instance.CheckExistUserName(UserName)) {
                MessageBox.Show("Tên tài khoản đã có người sử dụng, mời chọn tên khác!", "Thông báo!");
                return;
            }

            string DisplayName = txbDisplayName.Text;
            string Password = txbPassword.Text;
            string ReEnterPass = txbReEnterPass.Text;

            if (UserName == "" || UserName == null) {
                MessageBox.Show("Tên tài khoản không được trống!", "Thông Báo");
            }
            else if (Password == "" || Password == null) {
                MessageBox.Show("Mật khẩu không được trống!", "Thông Báo");
            }
            else if (ReEnterPass != Password) {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông Báo");
            }
            else {
                if (AccountModel.Instance.RegisterAccount(UserName, DisplayName, Password)) {
                    MessageBox.Show("Đã đăng kí tài khoản mới, giờ bạn có thể đăng nhập!", "Thông Báo");
                    this.Close();
                }
                else
                    MessageBox.Show("Có lỗi khi đăng kí tài khoản", "Thông Báo");
            }
        }

        private void txbUserName_TextChanged(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            if (AccountModel.Instance.CheckExistUserName(txbThis.Text)) {
                txbThis.ForeColor = Color.Red;
                lbExistUserName.Show();
            }
            else {
                txbThis.ForeColor = Color.Black;
                lbExistUserName.Hide();
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void txbPassword_TextChanged(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            if (txbThis.Text == "")
                lbGuidePass.Show();
            else
                lbGuidePass.Hide();
        }

        private void txbPassword_Enter(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            if (txbThis.Text == "")
                lbGuidePass.Show();
            else
                lbGuidePass.Hide();
        }

        private void txbPassword_Leave(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            TextBoxCustom.Instance.CheckTextBoxMatched(txbThis, txbReEnterPass);
        }

        private void txbReEnterPass_Leave(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            TextBoxCustom.Instance.CheckTextBoxMatched(txbPassword, txbThis);
        }

        #endregion
    }
}
