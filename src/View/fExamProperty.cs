using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem.Controller;
using TracNghiem.Model;

namespace TracNghiem.View {
    public partial class fExamProperty : Form {
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

        public fExamProperty(AccountController acc) {
            InitializeComponent();

            this.LoggedAccount = acc;

            LoadSubjectList();
        }
        
        #region Methods

        void LoadSubjectList() {
            cbbChooseSubject.DataSource = SubjectModel.Instance.getSubjectlist();
            cbbChooseSubject.DisplayMember = "Name";
        }

        object[] GetTime(int hour, int min, int sec) {
            object[] time = new object[3];
            time[0] = hour;
            time[1] = min;
            time[2] = sec;
            return time;
        }
        #endregion

        #region Events

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnDone_Click(object sender, EventArgs e) {
            int hour = Convert.ToInt32(nmudHour.Value);
            int min = Convert.ToInt32(nmudMinute.Value);
            int sec = Convert.ToInt32(nmudSecond.Value);

            int numQues = Convert.ToInt32(nmudNumQues.Value);
            SubjectController subjectChose = cbbChooseSubject.SelectedItem as SubjectController;
            object[] timeSetup = GetTime(hour, min, sec);

            fExam f = new fExam(LoggedAccount, timeSetup, numQues, subjectChose);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void cbbChooseSubject_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox thisCbb = sender as ComboBox;
            int idSubject = (thisCbb.SelectedItem as SubjectController).ID;
            nmudNumQues.Maximum = SubjectModel.Instance.GetSubjectNumQues(idSubject);
        }

        #endregion
    }
}
