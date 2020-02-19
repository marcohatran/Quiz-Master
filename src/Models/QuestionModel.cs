using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem.Model;

namespace TracNghiem.Controller {
    class QuestionModel {
        private static QuestionModel instance;

        public static QuestionModel Instance {
            get {
                if (instance == null)
                    instance = new QuestionModel();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private QuestionModel() { }

        public List<QuestionController> getQuesListBySubjectID(int id) {
            List<QuestionController> QuesList = new List<QuestionController>();
            string query = "SELECT * FROM dbo.Question WHERE idSubject = " + id;
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows) {
                QuestionController question = new QuestionController(item);
                QuesList.Add(question);
            }

            return QuesList;
        }

        public QuestionController GetQuestionByID(int id) {
            string query = "SELECT * FROM dbo.Question WHERE id = " + id;
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows) {
                return new QuestionController(item);
            }
            return null;
        }

        public bool AddMoreQues(int idSubject, string Content, string ContentA, string ContentB, string ContentC, string ContentD, char answer) {
            string query = string.Format("INSERT dbo.Question (idSubject, Content, ContentA, ContentB, ContentC, ContentD, Answer) VALUES ({0}, N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}')", idSubject, Content, ContentA, ContentB, ContentC, ContentD, answer);
            int dataNonQuery = DataTransfer.Instance.ExecuteNonQuery(query);
            return dataNonQuery > 0;
        }

        public bool UpdateQues(int id, int idSubject, string Content, string ContentA, string ContentB, string ContentC, string ContentD, char answer) {
            string query = string.Format("UPDATE dbo.Question SET idSubject = {0}, Content = N'{1}', ContentA = N'{2}', ContentB = N'{3}', ContentC = N'{4}', ContentD = N'{5}', Answer = '{6}' WHERE id = {7}", idSubject, Content, ContentA, ContentB, ContentC, ContentD, answer, id);
            int dataNonQuery = DataTransfer.Instance.ExecuteNonQuery(query);
            return dataNonQuery > 0;
        }

        public bool DeleteQues(int id) {
            string query = string.Format("DELETE dbo.Question WHERE id = {0}", id);
            int dataNonQuery = DataTransfer.Instance.ExecuteNonQuery(query);
            return dataNonQuery > 0;
        }

        public bool CheckColumnsName(DataGridView dtgv) {
            if (dtgv.Columns.Count < 6)
                return false;

            for (int i = 0; i < 6; i++) {
                if (!dtgv.Columns[i].HeaderText.Equals(QuestionController.ColumnsName[i], StringComparison.InvariantCultureIgnoreCase))
                    return false;
            }
            return true;
        }

        public int ImportDataFromDataTable(string subjectName, DataTable data ) {
            int result = -1;
            foreach (SubjectController item in SubjectModel.Instance.getSubjectlist()) {
                if (subjectName == item.Name) {
                    result = 0;
                    break;
                }
            }
            foreach (DataRow row in data.Rows) {
                string content = row["content"].ToString();
                string contentA = row["contentA"].ToString();
                string contentB = row["contentB"].ToString();
                string contentC = row["contentC"].ToString();
                string contentD = row["contentD"].ToString();
                char answer = Convert.ToChar(row["answer"]);

                string query = "EXEC dbo.UserSP_ImportQuesData @subjectName , @contentImp , @contentAImp , @contentBImp , @contentCImp , @contentDImp , @answerImp";

                result += DataTransfer.Instance.ExecuteNonQuery(query, new object[] { subjectName, content, contentA, contentB, contentC, contentD, answer });
            }
            return result;
        }
    }
}
