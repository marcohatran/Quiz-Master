using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiem.Model;

namespace TracNghiem.Controller {
    public class ExamModel {
        private static ExamModel instance;

        public static ExamModel Instance {
            get {
                if (instance == null)
                    instance = new ExamModel();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private ExamModel() { }

        public static int QuesWidth = 60;
        public static int QuesHeight = 60;

        public int CreateExam(int numQues, int idSubject) {
            string query = "EXEC dbo.UserSP_CreateExam @numQues , @idSubject";
            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { numQues, idSubject });
            return result;
        }

        public List<ExamController> GetQuesList() {
            List<ExamController> listExam = new List<ExamController>();
            string query = "SELECT * FROM dbo.Exam";
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                ExamController exam = new ExamController(item);
                listExam.Add(exam);
            }

            return listExam;
        }

        public int ChoseAnswer(int id, char answer) {
            string query = "EXEC dbo.UserSP_ChoseAnswer @id , @answer";
            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { id, answer });
            return result;
        }
        
        public ExamController GetExamByID(int id) {
            string query = "SELECT * FROM dbo.Exam WHERE id = " + id;
            DataTable data = DataTransfer.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows) {
                return new ExamController(item);
            }
            return null;
        }
        
        public int DoneExam() {
            string query = "EXEC dbo.UserSP_DoneExam";
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
