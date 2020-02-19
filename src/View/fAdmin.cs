using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class fAdmin : Form
    {
        #region Elements

        BindingSource QuesListExclusive = new BindingSource();

        BindingSource AccountList = new BindingSource();

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

        public fAdmin(AccountController acc)
        {
            InitializeComponent();

            this.LoggedAccount = acc;
            // ========================== QUESTION ===========================
            cbbAnswer.DataSource = QuestionController.AnsChar;
            
            LoadSubject();

            LoadAllQues();

            dtgvQues.DataSource = QuesListExclusive;

            AddQuesBinding();
            // =========================== ACCOUNT ===========================
            cbbAccountType.DataSource = AccountController.AccountType;

            LoadAccountList();

            dtgvAccount.DataSource = AccountList;
            
            AddAccountBinding();
        }

        #region Methods
        // ================================== SUBJECT & QUESTION METHODS ==================================
        void LoadSubject() {
            List<SubjectController> listSubject = SubjectModel.Instance.getSubjectlist();
            cbbSubject.DataSource = listSubject;
            cbbSubject.DisplayMember = "Name";
        }

        void LoadAllQues() {
            string query = "SELECT id AS [ID], idSubject AS [ID Môn học], Content AS [Nội dung], Answer AS [Đáp án] FROM dbo.Question";
            QuesListExclusive.DataSource = DataTransfer.Instance.ExecuteQuery(query);
        }

        void LoadQuestionBySubjectID(int id) {
            string queryExclusive = "SELECT id AS [ID], Content AS [Nội dung], Answer AS [Đáp án] FROM dbo.Question WHERE idSubject = " + id;
            QuesListExclusive.DataSource = DataTransfer.Instance.ExecuteQuery(queryExclusive);
        }

        void AddQuesBinding() {
            //txbQuesContent.DataBindings.Add(new Binding("Text", dtgvQues.DataSource, "Nội dung"));
            txbIDQues.DataBindings.Add(new Binding("Text", dtgvQues.DataSource, "ID"));
        }
        // ======================================= ACCOUNT METHODS =======================================
        void LoadAccountList(){
            string query = "SELECT UserName AS [TÊN TÀI KHOẢN], DisplayName AS [TÊN HIỂN THỊ], Ranking AS [XẾP HẠNG] FROM dbo.Account";
            AccountList.DataSource = DataTransfer.Instance.ExecuteQuery(query);
        }

        void AddAccountBinding() {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "TÊN TÀI KHOẢN"));
        }

        #endregion

        #region Events
        // =================================== SUBJECT & QUESTION EVENTS ===================================
        private void btnDone_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnViewSubject_Click(object sender, EventArgs e) {
            if (cbbSubject.SelectedItem == null)
                return;

            int idSubject = (cbbSubject.SelectedItem as SubjectController).ID;
            LoadQuestionBySubjectID(idSubject);
        }
        
        private void txbIDQues_TextChanged(object sender, EventArgs e) {
            if (dtgvQues.SelectedCells.Count > 0) {
                if (txbIDQues.Text != "") {
                    int idCurQues = int.Parse(txbIDQues.Text);
                    QuestionController CurQues = QuestionModel.Instance.GetQuestionByID(idCurQues);
                    txbQuesContent.Text = CurQues.Content;
                    txbContentA.Text = CurQues.ContentA;
                    txbContentB.Text = CurQues.ContentB;
                    txbContentC.Text = CurQues.ContentC;
                    txbContentD.Text = CurQues.ContentD;
                    cbbAnswer.SelectedItem = CurQues.Answer;
                }
            }
        }

        private void btnAddQues_Click(object sender, EventArgs e) {
            int idSubject = (cbbSubject.SelectedItem as SubjectController).ID;
            string QuesContent = txbQuesContent.Text;
            string ContentA = txbContentA.Text;
            string ContentB = txbContentB.Text;
            string ContentC = txbContentC.Text;
            string ContentD = txbContentD.Text;
            char Answer = Convert.ToChar(cbbAnswer.SelectedItem);

            if (MessageBox.Show("Bạn có chắc muốn thêm Câu hỏi này vào bộ môn: " + (cbbSubject.SelectedItem as SubjectController).Name, "Cảnh báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;
            if (QuestionModel.Instance.AddMoreQues(idSubject, QuesContent, ContentA, ContentB, ContentC, ContentD, Answer)) {
                MessageBox.Show("Thêm Câu hỏi thành công!", "Thông báo");
                LoadQuestionBySubjectID(idSubject);
            } else
                MessageBox.Show("Có lỗi khi thêm câu hỏi", "Thông báo");
        }

        private void btnDelQues_Click(object sender, EventArgs e) {
            if (txbIDQues.Text == null || txbIDQues.Text == "") {
                MessageBox.Show("Bạn phải chọn một Câu hỏi muốn xóa!", "Thông báo");
                return;
            }
            int id = Convert.ToInt32(txbIDQues.Text);
            int idSubject = (cbbSubject.SelectedItem as SubjectController).ID;
            if (MessageBox.Show("Bạn có chắc muốn xóa Câu hỏi " + id + " \nthuộc bộ môn " + (cbbSubject.SelectedItem as SubjectController).Name + " ? ", "Cảnh báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            if (QuestionModel.Instance.DeleteQues(id)) {
                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadQuestionBySubjectID(idSubject);
            } else
                MessageBox.Show("Có lỗi khi xóa", "Thông báo");
        }

        private void btnSaveQues_Click(object sender, EventArgs e) {
            int id = Convert.ToInt32(txbIDQues.Text);
            int idSubject = (cbbSubject.SelectedItem as SubjectController).ID;
            string QuesContent = txbQuesContent.Text;
            string ContentA = txbContentA.Text;
            string ContentB = txbContentB.Text;
            string ContentC = txbContentC.Text;
            string ContentD = txbContentD.Text;
            char Answer = Convert.ToChar(cbbAnswer.SelectedItem);

            if (QuestionModel.Instance.UpdateQues(id, idSubject, QuesContent, ContentA, ContentB, ContentC, ContentD, Answer)) {
                MessageBox.Show("Lưu thành công!", "Thông báo");
                LoadQuestionBySubjectID(idSubject);
            } else
                MessageBox.Show("Có lỗi khi lưu", "Thông báo");
        }

        private void btnCancelQues_Click(object sender, EventArgs e) {
            int idQues = Convert.ToInt32(txbIDQues.Text);
            QuestionController CurQues = QuestionModel.Instance.GetQuestionByID(idQues);
            txbQuesContent.Text = CurQues.Content;
            txbContentA.Text = CurQues.ContentA;
            txbContentB.Text = CurQues.ContentB;
            txbContentC.Text = CurQues.ContentC;
            txbContentD.Text = CurQues.ContentD;
            cbbAnswer.SelectedItem = CurQues.Answer;
        }

        private void btnAddSubject_Click(object sender, EventArgs e) {
            fImportSubject formImportSubject = new fImportSubject();
            this.Hide();
            formImportSubject.ImportDataEvent += FormImportSubject_ImportDataEvent;
            formImportSubject.ShowDialog();
            this.Show();
        }

        private void FormImportSubject_ImportDataEvent(object sender, EventArgs e) {
            LoadSubject();

            LoadAllQues();
        }

        private void btnDelSubject_Click(object sender, EventArgs e) {
            SubjectController SelectedSubject = cbbSubject.SelectedItem as SubjectController;
            if (SelectedSubject == null)
                return;

            if (MessageBox.Show("Bạn có muốn xóa môn " + SelectedSubject.Name + " không?\nSau khi xóa không thể hoàn tác lại được?", "Cảnh báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            MessageBox.Show("Xóa môn " + SelectedSubject.Name + " thành công!", "Thông báo");
            SubjectModel.Instance.DeleteSubject(SelectedSubject.ID);

            LoadSubject();

            LoadAllQues();
        }
        // ======================================= ACCOUNT EVENTS =======================================
        private void txbUserName_TextChanged(object sender, EventArgs e) {
            if (dtgvAccount.SelectedCells.Count > 0) {
                if (txbUserName.Text != "") {
                    AccountController CurAcc = AccountModel.Instance.GetAccountByUserName(txbUserName.Text);
                    txbDisplayName.Text = CurAcc.DisplayName;
                    if (CurAcc.Type == 1)
                        cbbAccountType.SelectedItem = AccountController.AccountType[1];
                    else
                        cbbAccountType.SelectedItem = AccountController.AccountType[0];
                    nmudTotalAns.Value = CurAcc.TotalAns;
                    nmudCorrectAns.Maximum = nmudTotalAns.Value;
                    nmudCorrectAns.Value = CurAcc.CorrectAns;
                    AccountModel.Instance.AutoUpdatePointByAns(nmudTotalAns, nmudCorrectAns, txbPoint, txbRanking);
                }
            }
        }
        
        private void btnDoneAccount_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e) {
            if (txbUserName.Text == null || txbUserName.Text == "") {
                MessageBox.Show("Bạn phải chọn một tài khoản muốn xóa!", "Cảnh báo!");
                return;
            }
            string UserName = txbUserName.Text;
            AccountController CurAcc = AccountModel.Instance.GetAccountByUserName(UserName);
            if (MessageBox.Show("Bạn có chắc muốn xóa Tài khoản:\n" + UserName + "\n(" + CurAcc.DisplayName + ") ?", "Cảnh báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            if (UserName == LoggedAccount.UserName)
                if (MessageBox.Show("Đây chính là tài khoản mà bạn đã đăng nhập, bạn có chắc chắn muốn xóa nó?", "Cảnh báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return; 

            if (AccountModel.Instance.DelAccount(UserName)) {
                MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo");
                if (UserName == LoggedAccount.UserName) {
                    if (deleteAccountEvent != null)
                        deleteAccountEvent(this, new EventArgs());
                    this.Close();
                    return;
                }
                LoadAccountList();
            } else
                MessageBox.Show("Có lỗi khi xóa tài khoản", "Thông báo");
        }

        private event EventHandler deleteAccountEvent;
        public event EventHandler DeleteAccountEvent {
            add {
                deleteAccountEvent += value;
            }
            remove {
                deleteAccountEvent -= value;
            }
        }

        private void btnSaveAcccount_Click(object sender, EventArgs e) {
            string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int TotalAns = Convert.ToInt32(nmudTotalAns.Value);
            int CorrectAns = Convert.ToInt32(nmudCorrectAns.Value);
            int type = 0;
            if (cbbAccountType.SelectedItem as string == AccountController.AccountType[1])
                type = 1;
            if (AccountModel.Instance.UpdateAccountByAdmin(UserName, DisplayName, type, TotalAns, CorrectAns)) {
                MessageBox.Show("Đã Lưu thay đổi!", "Thông báo");
                LoadAccountList();
                if (UserName == LoggedAccount.UserName)
                    if (updateAccountEvent != null)
                        updateAccountEvent(this, new AccountEvent(AccountModel.Instance.GetAccountByUserName(UserName)));
            } else
                MessageBox.Show("Có lỗi khi Lưu", "Thông báo");
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
        
        private void nmudCorrectAns_ValueChanged(object sender, EventArgs e) {
            NumericUpDown nmudThis = sender as NumericUpDown;
            AccountModel.Instance.AutoUpdatePointByAns(nmudTotalAns, nmudThis, txbPoint, txbRanking);
        }
        
        private void nmudTotalAns_ValueChanged(object sender, EventArgs e) {
            NumericUpDown nmudThis = sender as NumericUpDown;
            AccountModel.Instance.AutoUpdatePointByAns(nmudThis, nmudCorrectAns, txbPoint, txbRanking);
        }
        
        private void btnCancelAccount_Click(object sender, EventArgs e) {
            string UserName = txbUserName.Text;
            AccountController CurAcc = AccountModel.Instance.GetAccountByUserName(UserName);

            txbDisplayName.Text = CurAcc.DisplayName;
            cbbAccountType.SelectedItem = AccountController.AccountType[CurAcc.Type];
            nmudCorrectAns.Value = CurAcc.CorrectAns;
            nmudTotalAns.Value = CurAcc.TotalAns;
            AccountModel.Instance.AutoUpdatePointByAns(nmudTotalAns, nmudCorrectAns, txbPoint, txbRanking);
        }
        
        private void btnAddAccount_Click(object sender, EventArgs e) {
            fAddAccount formAddAcount = new fAddAccount();
            formAddAcount.AddAccountEvent += FormAddAcount_AddAccountEvent;
            formAddAcount.ShowDialog();
        }

        private void FormAddAcount_AddAccountEvent(object sender, AccountEvent e) {
            LoadAccountList();
        }

        private void btnReNewPassword_Click(object sender, EventArgs e) {
            string UserName = txbUserName.Text;
            AccountController CurAcc = AccountModel.Instance.GetAccountByUserName(UserName);
            if (MessageBox.Show("Bạn có chắc muốn đặt lại mật khẩu cho tài khoản:\n" + UserName + "\n(" + CurAcc.DisplayName + ") ?", "Cảnh báo!", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            AccountModel.Instance.ResetPassword(UserName);
            MessageBox.Show("Đã đặt lại mật khẩu thành công!\nMật khẩu sau khi được đặt lại là: 1", "Thông báo");
        }

        #endregion
    }
}
