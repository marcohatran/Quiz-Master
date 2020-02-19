using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem.Model
{
    public class SubjectController
    {
        public SubjectController(int id, string name) {
            this.ID = id;
            this.Name = name;
        }

        public SubjectController(DataRow row) {
            this.ID = (int)row["id"];
            this.Name = row["Name"].ToString();
        }
            
        private int iD;

        private string name;

        public int ID {
            get {
                return iD;
            }

            set {
                iD = value;
            }
        }

        public string Name {
            get {
                return name;
            }

            set {
                name = value;
            }
        }
    }
}
