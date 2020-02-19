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
    public partial class fExam : Form {
        #region Elements

        private AccountController loggedAccount;

        private int hour;

        private int min;

        private int sec;

        private int numQues;

        private SubjectController subjectExam;

        public AccountController LoggedAccount {
            get {
                return loggedAccount;
            }

            set {
                loggedAccount = value;
            }
        }

        public int NumQues {
            get {
                return numQues;
            }

            set {
                numQues = value;
            }
        }

        public SubjectController SubjectExam {
            get {
                return subjectExam;
            }

            set {
                subjectExam = value;
            }
        }

        public int Hour {
            get {
                return hour;
            }

            set {
                hour = value;
            }
        }

        public int Min {
            get {
                return min;
            }

            set {
                min = value;
            }
        }

        public int Sec {
            get {
                return sec;
            }

            set {
                sec = value;
            }
        }
        #endregion

        public fExam(AccountController acc, object[] time, int numQues, SubjectController subjectExam) {
            InitializeComponent();

            this.LoggedAccount = acc;
            this.Hour = (int)time[0];
            this.Min = (int)time[1];
            this.Sec = (int)time[2];
            this.NumQues = numQues;
            this.SubjectExam = subjectExam;

            LoadInformation();
        }

        #region Methods

        void LoadInformation() {
            lbDisplayName.Text = LoggedAccount.UserName;
            lbRanking.Text = LoggedAccount.Ranking;
            lbSubjectExam.Text = SubjectExam.Name;
            lbNumQuesExam.Text = NumQues.ToString();
            lbTimeExam.Text = TimeFormat(Hour, Min, Sec);
            lbTimeRemaining.Text = lbTimeExam.Text;
        }
        
        void LoadQuesDiagram() {
            flpQuesDiagram.Controls.Clear();

            List<ExamController> listExam = ExamModel.Instance.GetQuesList();
            foreach (ExamController item in listExam) {
                Button btnQues = new Button() { Width = ExamModel.QuesWidth, Height = ExamModel.QuesHeight };
                btnQues.Text = item.Id.ToString();
                btnQues.Tag = item;

                btnQues.Click += BtnQues_Click;

                flpQuesDiagram.Controls.Add(btnQues);
            }
        }

        void UpdateQuesDiagram(ExamController quesExam) {
            if (quesExam == null || flpQuesDiagram.Controls == null)
                return;
            
            foreach (var item in flpQuesDiagram.Controls) {
                Button btnWalker = item as Button;
                btnWalker.BackColor = SystemColors.ControlLight;
            }

            Button btnCurQues = flpQuesDiagram.Controls[quesExam.Id - 1] as Button;
            btnCurQues.BackColor = Color.LightCoral;
        }

        void LoadExam() {
            ExamModel.Instance.CreateExam(NumQues, SubjectExam.ID);

            LoadQuesDiagram();

            if (flpQuesDiagram.Controls.Count == 0)
                return;

            ExamController firstQuesExam = (flpQuesDiagram.Controls[0] as Button).Tag as ExamController;

            LoadQues(firstQuesExam);

            UpdateQuesDiagram(firstQuesExam);
        }

        void LoadRdbAnswer(ExamController quesExam) {
            if (quesExam.AnswerIN == 'A')
                rdbA.Checked = true;
            else if (quesExam.AnswerIN == 'B')
                rdbB.Checked = true;
            else if (quesExam.AnswerIN == 'C')
                rdbC.Checked = true;
            else if (quesExam.AnswerIN == 'D')
                rdbD.Checked = true;
            else {
                rdbA.Checked = false;
                rdbB.Checked = false;
                rdbC.Checked = false;
                rdbD.Checked = false;
            }
        }

        void LoadQues(ExamController quesExam) {
            if (quesExam == null)
                return;

            LoadRdbAnswer(quesExam);

            QuestionController ques = QuestionModel.Instance.GetQuestionByID(quesExam.IdQues);
            txbContent.Text = string.Format("Câu {0}: ", quesExam.Id);
            txbContent.Text += ques.Content;
            txbContent.Tag = quesExam;
            txbA.Text = ques.ContentA;
            txbB.Text = ques.ContentB;
            txbC.Text = ques.ContentC;
            txbD.Text = ques.ContentD;
        }

        char GetAnswerChar() {
            char answer;
            if (rdbA.Checked)
                answer = 'A';
            else if (rdbB.Checked)
                answer = 'B';
            else if (rdbC.Checked)
                answer = 'C';
            else if (rdbD.Checked)
                answer = 'D';
            else
                answer = 'X';
            return answer;
        }

        object[] GetResult() {
            string queryGetTotal = "SELECT COUNT(*) FROM dbo.Exam";
            string queryGetCorrect = "SELECT COUNT(*) FROM dbo.Exam WHERE isCorrect = 1";
            int Total = (int)DataTransfer.Instance.ExecuteScalar(queryGetTotal);
            int Correct = (int)DataTransfer.Instance.ExecuteScalar(queryGetCorrect);
            double Point;
            if (Total == 0)
                Point = 0.0;
            else
                Point = (Correct * 100.0) / Total;
            object[] result = new object[3] { Total, Correct, Point };
            return result;
        }

        void SubmitExam() {
            object[] result = GetResult();

            int total = (int)result[0];
            int correct = (int)result[1];
            double point = (double)result[2];

            MessageBox.Show("Bạn đã làm đúng " + correct + " / " + total + " câu.\nĐiểm của bạn là: " + point, "Thông báo");

            ExamModel.Instance.UpdateAccountExamed(LoggedAccount.UserName, total, correct);

            btnStartORDone.Hide();

            timerCountDown.Interval = 1000000000;
        }

        string TimeFormat(int hour, int min, int sec) {
            return string.Format("{0:00}:{1:00}:{2:00}", hour, min, sec);
        }

        #endregion

        #region Events

        private void BtnQues_Click(object sender, EventArgs e) {
            Button btnThis = sender as Button;

            ExamController quesExam = ExamModel.Instance.GetExamByID((btnThis.Tag as ExamController).Id);

            LoadQues(quesExam);

            UpdateQuesDiagram(quesExam);
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            if (timerCountDown.Enabled) {
                if (MessageBox.Show("Bạn có chắc muốn thoát bài thi?\nMọi câu trả lời của bạn sẽ không được ghi nhận!", "Cảnh báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;
            }
            this.Close();
        }

        private void btnStartORDone_Click(object sender, EventArgs e) {
            if (timerCountDown.Enabled) {
                if (MessageBox.Show("Bạn có chắc muốn nộp bài không?\nSau khi nộp bài không thể hoàn tác lại được?", "Cảnh báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return;

                timerCountDown.Stop();

                SubmitExam();
            }
            else {
                btnStartORDone.Text = "Nộp bài";
                timerCountDown.Start();

                LoadExam();
            }
        }

        private void btnNextQues_Click(object sender, EventArgs e) {
            if (txbContent.Tag == null)
                return;
            
            ExamController CurQuesExam = txbContent.Tag as ExamController;

            int id = CurQuesExam.Id;
            char answer = GetAnswerChar();
            if (answer != CurQuesExam.AnswerIN)
                ExamModel.Instance.ChoseAnswer(id, answer);

            if (id >= NumQues)
                return;

            ExamController NextQuesExam = ExamModel.Instance.GetExamByID(id + 1);

            LoadQues(NextQuesExam);

            UpdateQuesDiagram(NextQuesExam);
        }

        private void btnPrevQues_Click(object sender, EventArgs e) {
            if (txbContent.Tag == null)
                return;
            
            ExamController CurQuesExam = txbContent.Tag as ExamController;

            int id = CurQuesExam.Id;
            char answer = GetAnswerChar();
            if (answer != CurQuesExam.AnswerIN)
                ExamModel.Instance.ChoseAnswer(id, answer);

            if (id <= 1)
                return;

            ExamController PrevQuesExam = ExamModel.Instance.GetExamByID(id - 1);

            LoadQues(PrevQuesExam);

            UpdateQuesDiagram(PrevQuesExam);
        }

        private void timerCountDown_Tick(object sender, EventArgs e) {
            lbTimeRemaining.Text = string.Format("{0:00}:{1:00}:{2:00}", Hour, Min, Sec);

            if (Hour == 0 && Min == 0 && Sec == 0) {
                timerCountDown.Stop();
                MessageBox.Show("Thời gian làm bài đã hết!", "Thông báo");

                SubmitExam();
            }

            Sec--;
            if (Sec < 0) {
                Min--;
                Sec = 59;
            }
            if (Min < 0) {
                Hour--;
                Min = 59;
            }
        }

        private void fExam_FormClosed(object sender, FormClosedEventArgs e) {
            ExamModel.Instance.DoneExam();
        }

        #endregion
    }
}
