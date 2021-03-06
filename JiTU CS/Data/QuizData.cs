﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiTU_CS.Data {
    public class QuizData {   
        
        #region properties
        public string Name {
            get {
                return name_internal;
            }
            set {
                name_internal = value;
            }
        }

        public int id {
            get {
                return id_internal;
            }
            set {
                id_internal = value;
            }
        }

        
        public List<QuestionData> questions {
            get {
                return questions_internal;
            }
        }

        public DateTime Added {
            get {
                return added_internal;
            }
            set {
                added_internal = value;
            }
        }

        public DateTime Due {
            get {
                return due_internal;
            }
            set {
                due_internal = value;
            }
        }
        #endregion

        #region functions
        public QuizData() {
            id_internal = id;
            questions_internal = new List<QuestionData>();
            added_internal = new DateTime();
            due_internal = new DateTime();
        }

        public QuizData(int id) {
            id_internal = id;
            questions_internal = new List<QuestionData>();
            added_internal = new DateTime();
            due_internal = new DateTime();
        }

        #endregion

        #region members
        private string name_internal;
        private int id_internal;
        private List<QuestionData> questions_internal;

        private DateTime added_internal;
        private DateTime due_internal;
        #endregion

    }
}
