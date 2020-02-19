using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracNghiem.Model;

namespace TracNghiem.Controller {
    public class SubjectModel {
        private static SubjectModel instance;

        public static SubjectModel Instance {
            get {
                if (instance == null)
                    instance = new SubjectModel();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private SubjectModel() { }

        public List<SubjectController> getSubjectlist() {
            List<SubjectController> list = new List<SubjectController>();

            string query = "SELECT * FROM dbo.Subject";

            DataTable data = DataTransfer.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                SubjectController subject = new SubjectController(item);
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
