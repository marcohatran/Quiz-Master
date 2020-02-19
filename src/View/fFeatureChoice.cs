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
    public partial class fFeatureChoice : Form
    {
        #region Elements

        private static bool isDeletedLoggedAccount = false;

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

        public fFeatureChoice(AccountController acc)
        {
            InitializeComponent();

            isDeletedLoggedAccount = false;

            this.LoggedAccount = acc;
            lbDisplayName.Text = LoggedAccount.DisplayName;
            if (LoggedAccount.Type == 0)
                btnAdmin.Hide();
        }

        #region Methods
        
            
        #endregion

        #region Events

        private void btnExam_Click(object sender, EventArgs e)
        {
            AccountController AlwaysUpdateAccount = AccountModel.Instance.GetAccountByUserName(LoggedAccount.UserName);
            fExamProperty formExamProperties = new fExamProperty(AlwaysUpdateAccount);
            this.Hide();
            formExamProperties.ShowDialog();
            this.Show();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            AccountController AlwaysUpdateAccount = AccountModel.Instance.GetAccountByUserName(LoggedAccount.UserName);
            fAccountInfo f = new fAccountInfo(AlwaysUpdateAccount);
            f.UpdateAccountEvent += f_UpdateAccountEvent;
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void f_UpdateAccountEvent(object sender, AccountEvent e) {
            lbDisplayName.Text = e.Acc.DisplayName;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            fAdmin formAdmin = new fAdmin(LoggedAccount);
            this.Hide();
            formAdmin.UpdateAccountEvent += FormAdmin_UpdateAccountEvent;
            formAdmin.DeleteAccountEvent += FormAdmin_DeleteAccountEvent;
            formAdmin.ShowDialog();
            this.Show();
        }

        private void FormAdmin_DeleteAccountEvent(object sender, EventArgs e) {
            isDeletedLoggedAccount = true;
            this.Close();
        }

        private void FormAdmin_UpdateAccountEvent(object sender, AccountEvent e) {
            lbDisplayName.Text = e.Acc.DisplayName;
            if (e.Acc.Type == 0)
                btnAdmin.Hide();
        }
        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fFeatureChoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDeletedLoggedAccount == false)
                if (MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) {
                    e.Cancel = true;
                }
        }

        #endregion
    }
}
