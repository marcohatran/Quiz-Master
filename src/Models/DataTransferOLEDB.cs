using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace TracNghiem.Controller {
    public class DataTransferOLEDB {
        private static DataTransferOLEDB instance;

        public static DataTransferOLEDB Instance {
            get {
                if (instance == null)
                    instance = new DataTransferOLEDB();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private DataTransferOLEDB() { }

        public DataTable GetExcelData(string filePath, string sheetName = null, ComboBox cbb = null) {
            DataTable data = new DataTable();

            string ExcelPath = string.Empty;
            if (filePath.EndsWith(".xlsx"))
                ExcelPath = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties = \"Excel 12.0 Xml; HDR=YES\";", filePath);
            else
                ExcelPath = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties = \"Excel 8.0; HDR=YES\";", filePath);

            using (OleDbConnection connection = new OleDbConnection(ExcelPath)) {
                connection.Open();

                if (cbb != null) {
                    cbb.Items.Clear();

                    DataTable schemaData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow item in schemaData.Rows) {
                        string tempSheetName = item["TABLE_NAME"].ToString();
                        if (tempSheetName.EndsWith("$") || tempSheetName.EndsWith("$'"))
                            cbb.Items.Add(tempSheetName);
                    }
                    cbb.SelectedItem = cbb.Items[0];
                    return null;
                }

                string query = string.Format("SELECT * FROM [{0}]", sheetName);
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataAdapter oledbAdapter = new OleDbDataAdapter(command);
                oledbAdapter.Fill(data);

                connection.Close();
            }
            return data;
        }
    }
}
