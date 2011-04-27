using System;
using System.Collections.Generic;
using System.Text;
using JiTU_CS.Data;

namespace JiTU_CS.Entity {
    class QuizEntity : BaseEntity {

        #region Constructor/Destructor

        public QuizEntity() {
        }

        ~QuizEntity() {

        }

        #endregion

        #region CRUD

        #region CREATE

        public void CreateQuiz(QuizData theQuiz) {

            theQuiz.id = NextId;
            if (DataReader != null)
                DataReader.Close();

            SQL = "INSERT INTO `quizzes` (`quiz_id`, `name`, `open_date`, `due_date`) VALUES " +
                "(\"" + theQuiz.id + "\", \"" + theQuiz.Name + "\", \"" + theQuiz.Added.ToString("yyyy-MM-dd") +
                "\", \"" + theQuiz.Due.ToString("yyyy-MM-dd") + "\");";

            InitializeCommand();

            OpenConnection();
            int result = ExecuteStoredProcedure();

            if (result == 0)
                throw new Exception("Could Not add the quiz to the database");

            QuestionEntity temp = new QuestionEntity();

            for (int i = 0; i < theQuiz.questions.Count; i++) {

                temp.CreateQuestion(theQuiz.questions[i]);
                if (DataReader != null)
                    DataReader.Close();

                SQL = "INSERT INTO `rel_quizzes_questions` (`quiz_id`, `question_id`) VALUES (\"" +
                    theQuiz.id + "\", \"" + theQuiz.questions[i].id + "\");";

                InitializeCommand();
                OpenConnection();

                result = ExecuteStoredProcedure();

                if (result == 0)
                    throw new Exception("Cannot associate this question with this quiz");

            }

            CloseConnection();

        }

        #endregion

        #region READ

        public QuizData ReadQuiz(int id) {
            QuizData return_value = null;

            if (DataReader != null)
                DataReader.Close();

            SQL = "SELECT * FROM `quizzes` q WHERE q.`quiz_id` = \"" + id + "\";";

            InitializeCommand();
            OpenConnection();

            DataReader = Command.ExecuteReader();

            if (DataReader.HasRows) {
                DataReader.Read();
                return_value = new QuizData(DataReader.GetUInt16("quiz_id"));
                return_value.Name = DataReader.GetString("name");
                return_value.Added = DataReader.GetDateTime("open_date");
                return_value.Due = DataReader.GetDateTime("due_date");
            }

            CloseConnection();

            QuestionEntity temp = new QuestionEntity();

            return_value.questions.AddRange(temp.ReadQuestions(return_value));

            if (return_value == null)
                throw new Exception("Could not find specified Quiz");

            

            return return_value;
        }

        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        #endregion

        #endregion

        #region Properties

        public int NextId {
            get {
                int return_data = 0;

                if (DataReader != null)
                    DataReader.Close();

                SQL = "SELECT MAX(q.`quiz_id`) FROM `quizzes` q;";

                InitializeCommand();
                OpenConnection();

                DataReader = Command.ExecuteReader();

                if (DataReader.HasRows) {
                    DataReader.Read();
                    return_data = DataReader.GetUInt16("MAX(q.`quiz_id`)");
                }
                CloseConnection();
                return_data++;

                return return_data;
            }

        }


        #endregion


    }
}
