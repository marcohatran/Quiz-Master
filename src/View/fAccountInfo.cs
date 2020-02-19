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
    public partial class fAccountInfo : Form {
        #region Elements

        private AccountController loggedAccount;

        public AccountController LoggedAccount {
            get {
                return loggedAccount;
            }

            set {
                loggedAccount = value;
            }
        }

        #endregion

        public fAccountInfo(AccountController acc) {
            InitializeComponent();

            this.LoggedAccount = acc;

            ShowInfo();
        }

        #region Methods

        void ShowInfo() {
            txbUserName.Text = LoggedAccount.UserName;
            txbDisplayName.Text = LoggedAccount.DisplayName;
            txbCorrectAns.Text = LoggedAccount.CorrectAns.ToString();
            txbWrongAns.Text = LoggedAccount.WrongAns.ToString();
            txbPoint.Text = string.Format("{0:F2}", LoggedAccount.Point);
            txbRank.Text = LoggedAccount.Ranking;
            if (LoggedAccount.Type == 1) {
                txbType.Text = "Admin";
                //txbType.ForeColor = Color.Red;
            } else {
                txbType.Text = "Thí sinh";
                //txbType.ForeColor = Color.YellowGreen; 
            }
        }

        void UpdateAccount() {
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPass.Text;
            string reEnterPass = txbReEnterPass.Text;
            if (!newpass.Equals(reEnterPass))
                MessageBox.Show("Mật khẩu mới không trùng khớp", "Thông Báo");
            else {
                if (AccountModel.Instance.UpdateAccountInfo(LoggedAccount.UserName, displayName, password, newpass)) {
                    MessageBox.Show("Thay đổi thông tin tài khoản thành công!", "Thông Báo");
                    if (updateAccountEvent != null)
                        updateAccountEvent(this, new AccountEvent(AccountModel.Instance.GetAccountByUserName(LoggedAccount.UserName)));
                } else {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu để xác thực!", "Thông Báo");
                }
            }
        }

        #endregion

        #region Events

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            UpdateAccount();
        }

        private event EventHandler<AccountEvent> updateAccountEvent;
        public event EventHandler<AccountEvent> UpdateAccountEvent {
            add {
                updateAccountEvent += value;
            }
            remove {
                updateAccountEvent -= value;
            }
        }

        private void txbNewPass_Leave(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            TextBoxCustom.Instance.CheckTextBoxMatched(txbThis, txbReEnterPass);
        }

        private void txbReEnterPass_Leave(object sender, EventArgs e) {
            TextBox txbThis = sender as TextBox;
            TextBoxCustom.Instance.CheckTextBoxMatched(txbNewPass, txbThis);
        }

        #endregion
    }
}
