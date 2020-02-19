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
    public partial class fAddAccount : Form {
        public fAddAccount() {
            InitializeComponent();

            cbbAccountType.DataSource = AccountController.AccountType;

            AccountModel.Instance.AutoUpdatePointByAns(nmudTotalAns, nmudCorrectAns, txbPoint, txbRanking);

            lbExistUserName.Hide();

            lbGuidePass.Hide();
        }

        #region Methods

        #endregion

        #region Events

        private void btnSaveAddAccount_Click(object sender, EventArgs e) {
            string UserName = txbUserName.Text;

            if (AccountModel.Instance.CheckExistUserName(UserName)) {
                MessageBox.Show("Tên tài khoản đã tồn tại!", "Thông báo");
                return;
            }

            string DisplayName = txbDisplayName.Text;
            string Password = txbPassword.Text;
            string ReEnterPass = txbReEnterPass.Text;
            int type = 0;
            if (cbbAccountType.SelectedItem as string == AccountController.AccountType[1])
                type = 1;
            int TotalAns = Convert.ToInt32(nmudTotalAns.Value);
            int CorrectAns = Convert.ToInt32(nmudCorrectAns.Value);
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
                if (AccountModel.Instance.AddAccountByAdmin(UserName, DisplayName, Password, type, TotalAns, CorrectAns)) {
                    MessageBox.Show("Thêm tài khoản mới thành công!", "Thông Báo");
                    if (addAccountEvent != null)
                        addAccountEvent(this, new AccountEvent(AccountModel.Instance.GetAccountByUserName(UserName)));
                }
                else
                    MessageBox.Show("Có lỗi khi thêm tài khoản!", "Thông Báo");
            }
        }

        private void btnDoneAddAccount_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void nmudCorrectAns_ValueChanged(object sender, EventArgs e) {
            NumericUpDown nmudThis = sender as NumericUpDown;
            AccountModel.Instance.AutoUpdatePointByAns(nmudTotalAns, nmudThis, txbPoint, txbRanking);
        }

        private void nmudTotalAns_ValueChanged(object sender, EventArgs e) {
            NumericUpDown nmudThis = sender as NumericUpDown;
            AccountModel.Instance.AutoUpdatePointByAns(nmudThis, nmudCorrectAns, txbPoint, txbRanking);
        }

        private event EventHandler<AccountEvent> addAccountEvent;
        public event EventHandler<AccountEvent> AddAccountEvent {
            add {
                addAccountEvent += value;
            }
            remove {
                addAccountEvent -= value;
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
