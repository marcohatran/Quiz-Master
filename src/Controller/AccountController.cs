using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TracNghiem.Model;
using System.Security.Cryptography;

namespace TracNghiem.Controller
{
    public class AccountController
    {
        private static AccountController instance;

        public static AccountController Instance {
            get {
                if (instance == null)
                    instance = new AccountController();
                return instance;
            }
            private set => instance = value;
        }
        private AccountController() { }

        public string ConvertToSHA256(string input) {
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder output = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    output.Append(bytes[i].ToString("x2"));
                }

                return output.ToString();
            }
        }

        public bool Login(string UserName, string Password) {
            string SecurityPass = ConvertToSHA256(Password);

            string query = "EXEC UserSP_Login @username , @password";

            DataTable result = DataTransfer.Instance.ExecuteQuery(query, new object[] { UserName, SecurityPass });

            return result.Rows.Count > 0;
        }

        public bool RegisterAccount(string UserName, string DisplayName, string Password) {
            string SecurityPass = ConvertToSHA256(Password);

            string query = "EXEC UserSP_RegisterAccount @UserName , @DisplayName , @Password ";

            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { UserName, DisplayName, SecurityPass });

            return result > 0;
        }

        public Account GetAccountByUserName(string UserName) {
            string query = "EXEC UserSP_GetAccountByUserName @username";

            DataTable data = DataTransfer.Instance.ExecuteQuery(query, new object[]{ UserName });

            foreach (DataRow item in data.Rows) {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccountInfo(string UserName, string DisplayName, string Password, string NewPass) {
            string SecurityPass = ConvertToSHA256(Password);
            string SecurityNewPass = ConvertToSHA256(NewPass);

            string query = "EXEC UserSP_UpdateAccountInfo @username , @displayName , @password , @newPass";

            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { UserName, DisplayName, SecurityPass, SecurityNewPass });

            return result > 0;
        }

        public bool DelAccount(string UserName) {
            string query = string.Format("DELETE dbo.Account WHERE UserName = N'{0}'", UserName);

            int result = DataTransfer.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccountByAdmin(string UserName, string DisplayName, int type, int TotalAns, int CorrectAns) {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{0}', type = {1}, TotalAns = {2}, CorrectAns = {3} WHERE UserName = N'{4}'", DisplayName, type, TotalAns, CorrectAns, UserName);

            int result = DataTransfer.Instance.ExecuteNonQuery(query); 

            return result > 0;
        }

        public bool AddAccountByAdmin(string UserName, string DisplayName, string Password, int type, int TotalAns, int CorrectAns) {
            string SecurityPass = ConvertToSHA256(Password);

            string query = string.Format("EXEC dbo.UserSP_AddAccountByAdmin N'{0}', N'{1}', N'{2}', {3}, {4}, {5}", UserName, DisplayName, SecurityPass, type, TotalAns, CorrectAns);

            int result = DataTransfer.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool CheckExistUserName(string UserName) {
            string query = "EXEC dbo.UserSP_GetAccountByUserName @UserName";

            DataTable data = DataTransfer.Instance.ExecuteQuery(query, new object[] { UserName });

            return data.Rows.Count > 0;
        }

        public int ResetPassword(string UserName) {
            string query = "EXEC dbo.UserSP_ResetPassword @userName";

            int result = DataTransfer.Instance.ExecuteNonQuery(query, new object[] { UserName });

            return result;
        }

        public void AutoUpdatePointByAns(NumericUpDown nmudTotalAns, NumericUpDown nmudCorrectAns, TextBox txbPoint, TextBox txbRanking) {
            int TotalAns = Convert.ToInt32(nmudTotalAns.Value);
            nmudCorrectAns.Maximum = nmudTotalAns.Value;
            int CorrectAns = Convert.ToInt32(nmudCorrectAns.Value);
            double point = 0.0;
            string ranking = "Beginner";
            if (TotalAns != 0) {
                point = (CorrectAns * 100.0) / TotalAns;
                if (point >= 99 && point <= 100)
                    ranking = "Pro Player";
                else if (point >= 95 && point < 99)
                    ranking = "Thách Đấu";
                else if (point >= 90 && point < 95)
                    ranking = "Cao Thủ";
                else if (point >= 80 && point < 90)
                    ranking = "Kim Cương";
                else if (point >= 70 && point < 80)
                    ranking = "Bạch Kim";
                else if (point >= 60 && point < 70)
                    ranking = "Vàng";
                else if (point >= 50 && point < 60)
                    ranking = "Bạc";
                else if (point >= 40 && point < 50)
                    ranking = "Đồng";
                else
                    ranking = "Giấy";
            }
            txbPoint.Text = string.Format("{0:F2}", point);
            txbRanking.Text = ranking;
        }
    }
}
