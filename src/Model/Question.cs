using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem.Model {
    public class Question {
        public Question(int id, int idSubject, string content, string contentA, string contentB, string contentC, string contentD, char answer) {
            this.Id = id;
            this.IdSubject = idSubject;
            this.Content = content;
            this.ContentA = contentA;
            this.ContentB = contentB;
            this.ContentC = contentC;
            this.ContentD = contentD;
            this.Answer = answer;
        }

        public Question(DataRow row) {
            this.Id = (int)row["id"];
            this.IdSubject = (int)row["idSubject"];
            this.Content = row["content"].ToString();
            this.ContentA = row["contentA"].ToString();
            this.ContentB = row["contentB"].ToString();
            this.ContentC = row["contentC"].ToString();
            this.ContentD = row["contentD"].ToString();
            this.Answer = Convert.ToChar(row["answer"]);
        }

        public static string[] ColumnsName = new string[] { "content", "contentA", "contentB", "contentC", "contentD", "answer" };

        public static char[] AnsChar = new char[] { 'A', 'B', 'C', 'D' };

        private int id;

        private int idSubject;

        private string content;

        private string contentA;

        private string contentB;

        private string contentC;

        private string contentD;

        private char answer;

        public int Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        public int IdSubject {
            get {
                return idSubject;
            }

            set {
                idSubject = value;
            }
        }

        public string Content {
            get {
                return content;
            }

            set {
                content = value;
            }
        }

        public string ContentA {
            get {
                return contentA;
            }

            set {
                contentA = value;
            }
        }

        public string ContentB {
            get {
                return contentB;
            }

            set {
                contentB = value;
            }
        }

        public string ContentC {
            get {
                return contentC;
            }

            set {
                contentC = value;
            }
        }

        public string ContentD {
            get {
                return contentD;
            }

            set {
                contentD = value;
            }
        }

        public char Answer {
            get {
                return answer;
            }

            set {
                answer = value;
            }
        }
    }
}
