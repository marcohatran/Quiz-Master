using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TracNghiem.Model {
    public class TextBoxCustom : TextBox {
        private static TextBoxCustom instance;

        public static TextBoxCustom Instance {
            get {
                if (instance == null)
                    instance = new TextBoxCustom();
                return instance;
            }

            set {
                instance = value;
            }
        }

        private TextBoxCustom() { }

        public void CheckTextBoxMatched(TextBox txbA, TextBox txbB) {
            if (txbA.Text != txbB.Text && txbA.Text != "" && txbB.Text != "") {
                txbB.BackColor = Color.LightCoral;
            }
            else {
                txbB.BackColor = Color.Empty;
            }
        }
    }
}
