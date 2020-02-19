using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiem.Model;

namespace TracNghiem.Controller {
    public class SubjectController {
        private static SubjectController instance;

        public static SubjectController Instance {
            get {
                if (instance == null)
                    instance = new SubjectController();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private SubjectController() { }

        public List<Subject> getSubjectlist() {
            List<Subject> list = new List<Subject>();

            string query = "SELECT * FROM dbo.Subject";

            DataTable data = DataTransfer.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                Subject subject = new Subject(item);
                list.Add(subject);
            }

            return list;
        }

        public int GetSubjectNumQues(int idSubject) {
            string query = "SELECT COUNT(*) FROM dbo.Question WHERE idSubject = " + idSubject;

            int result = (int)DataTransfer.Instance.ExecuteScalar(query);

            return result;
        }

        public int DeleteSubject(int idSubject) {
            string query = "EXEC dbo.UserSP_DeleteSubject @idSubject";

            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { idSubject });

            return result;
        }
    }
}
