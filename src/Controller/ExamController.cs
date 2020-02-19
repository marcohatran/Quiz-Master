using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiem.Model;

namespace TracNghiem.Controller {
    public class ExamController {
        private static ExamController instance;

        public static ExamController Instance {
            get {
                if (instance == null)
                    instance = new ExamController();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private ExamController() { }

        public static int QuesWidth = 60;
        public static int QuesHeight = 60;

        public int CreateExam(int numQues, int idSubject) {
            string query = "EXEC dbo.UserSP_CreateExam @numQues , @idSubject";
            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { numQues, idSubject });
            return result;
        }

        public List<Exam> GetQuesList() {
            List<Exam> listExam = new List<Exam>();
            string query = "SELECT * FROM dbo.Exam";
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                Exam exam = new Exam(item);
                listExam.Add(exam);
            }

            return listExam;
        }

        public int ChoseAnswer(int id, char answer) {
            string query = "EXEC dbo.UserSP_ChoseAnswer @id , @answer";
            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { id, answer });
            return result;
        }

        public Exam GetExamByID(int id) {
            string query = "SELECT * FROM dbo.Exam WHERE id = " + id;
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows) {
                return new Exam(item);
            }
            return null;
        }

        public int DoneExam() {
            string query = "EXEC dbo.UserSP_DoneExam";
            int result = DataTransfer.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int UpdateStatusCurQues(int id, int isCurQues) {
            string query = string.Format("UPDATE dbo.Exam SET isCurQues = {0} WHERE id = {1}", isCurQues, id);
            int result = DataTransfer.Instance.ExecuteNonQuery(query);
            return result;
        }

        public int UpdateAccountExamed(string userName, int totalAns, int correctAns) {
            string query = "EXEC dbo.UserSP_UpdateAccountExamed @username , @totalAns , @correctAns";
            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { userName, totalAns, correctAns });
            return result;
        }
    }
}
