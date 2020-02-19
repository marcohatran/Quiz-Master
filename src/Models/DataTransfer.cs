using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TracNghiem.Controller
{
    public class DataTransfer
    {
        private static DataTransfer instance;

        public static DataTransfer Instance {
            get {
                if (instance == null)
                    instance = new DataTransfer();
                return instance;
            }
            private set { DataTransfer.instance = value; }
        }
        private DataTransfer() { }

        private string connectSTR = "Data Source=DESKTOP-GK69KBF;Initial Catalog=R3ME;Integrated Security=True";
        
        public DataTable ExecuteQuery(string query, object[] parameter = null){
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectSTR)) {
                connection.Open();
                SqlCommand queryCommand = new SqlCommand(query, connection);

                if (parameter != null) {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter) {
                        if (item.Contains('@')) {
                            queryCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryCommand);
                dataAdapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int dataNonQuery = 0;

            using (SqlConnection connection = new SqlConnection(connectSTR)) {
                connection.Open();
                SqlCommand queryCommand = new SqlCommand(query, connection);

                if (parameter != null) {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter) {
                        if (item.Contains('@')) {
                            queryCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                dataNonQuery = queryCommand.ExecuteNonQuery();
                connection.Close();
            }
            return dataNonQuery;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object dataScalar = 0;

            using (SqlConnection connection = new SqlConnection(connectSTR)) {
                connection.Open();
                SqlCommand queryCommand = new SqlCommand(query, connection);

                if (parameter != null) {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string item in listParameter) {
                        if (item.Contains('@')) {
                            queryCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                dataScalar = queryCommand.ExecuteScalar();
                connection.Close();
            }
            return dataScalar;
        }
    }
}
