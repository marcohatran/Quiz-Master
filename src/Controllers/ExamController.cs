﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracNghiem.Model {
    public class ExamController {
        public ExamController(int id, int idQues, char answerIn, int isCorrect) {
            this.Id = id;
            this.IdQues = idQues;
            this.AnswerIN = answerIn;
            this.IsCorrect = isCorrect;
        }

        public ExamController(DataRow row) {
            this.Id = (int)row["id"];
            this.IdQues = (int)row["idQues"];
            if (row["AnswerIn"] == null)
                this.AnswerIN = 'X';
            else
                this.AnswerIN = Convert.ToChar(row["AnswerIn"]);
            this.IsCorrect = (int)row["isCorrect"];
        }

        private int id;

        private int idQues;

        private char answerIN;

        private int isCorrect;

        public int Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        public int IdQues {
            get {
                return idQues;
            }

            set {
                idQues = value;
            }
        }

        public char AnswerIN {
            get {
                return answerIN;
            }

            set {
                answerIN = value;
            }
        }

        public int IsCorrect {
            get {
                return isCorrect;
            }

            set {
                isCorrect = value;
            }
        }
    }
}
