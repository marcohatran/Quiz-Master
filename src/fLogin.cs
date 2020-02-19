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
using TracNghiem.View;

namespace TracNghiem
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        #region Methods

        public bool LoginCheck(string UserName, string Password){
            return AccountModel.Instance.Login(UserName, Password);
        }

        #endregion

        #region Events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = tbUserName.Text;
            string Password = tbPassword.Text;
            if (LoginCheck(UserName, Password)) {
                AccountController LoggedAccount = AccountModel.Instance.GetAccountByUserName(UserName);
                fFeatureChoice f = new fFeatureChoice(LoggedAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            } else
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.", "Thông báo");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình không?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) {
                e.Cancel = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            fRegister formRegister = new fRegister();
            formRegister.Show();
        }

        #endregion
    }
}
