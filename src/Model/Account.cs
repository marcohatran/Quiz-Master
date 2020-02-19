using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem.Model {
    public class Account {
        public Account(string userName, string displayName, string password, int type, int totalAnsint, int correctAns, int wrongAns, float point, string ranking) {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Password = password;
            this.Type = type;
            this.TotalAns = totalAns;
            this.CorrectAns = correctAns;
            this.WrongAns = wrongAns;
            this.Point = point;
            this.Ranking = ranking;
        }

        public Account(DataRow row) {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.Password = row["Password"].ToString();
            this.Type = (int)row["Type"];
            this.TotalAns = (int)row["TotalAns"];
            this.CorrectAns = (int)row["CorrectAns"];
            this.WrongAns = (int)row["WrongAns"];
            this.Point = (double)Convert.ToDouble(row["Point"]);
            this.Ranking = row["Ranking"].ToString();
        }

        public static string[] AccountType = new string[] { "Thí Sinh", "Admin" };

        private string userName;

        private string displayName;

        private string password;

        private int type;

        private int totalAns;

        private int correctAns;

        private int wrongAns;

        private double point;

        private string ranking;

        public string UserName {
            get {
                return userName;
            }

            set {
                userName = value;
            }
        }

        public string DisplayName {
            get {
                return displayName;
            }

            set {
                displayName = value;
            }
        }

        public string Password {
            get {
                return password;
            }

            set {
                password = value;
            }
        }

        public int Type {
            get {
                return type;
            }

            set {
                type = value;
            }
        }

        public int TotalAns {
            get {
                return totalAns;
            }

            set {
                totalAns = value;
            }
        }

        public int CorrectAns {
            get {
                return correctAns;
            }

            set {
                correctAns = value;
            }
        }

        public int WrongAns {
            get {
                return wrongAns;
            }

            set {
                wrongAns = value;
            }
        }

        public double Point {
            get {
                return point;
            }

            set {
                point = value;
            }
        }

        public string Ranking {
            get {
                return ranking;
            }

            set {
                ranking = value;
            }
        }

        
    }

    public class AccountEvent : EventArgs {
        private Account acc;

        public Account Acc {
            get {
                return acc;
            }

            set {
                acc = value;
            }
        }

        public AccountEvent(Account acc) {
            this.Acc = acc;
        }
    }
}
