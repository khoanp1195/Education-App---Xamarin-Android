using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;
using System.IO;

using Android.Database;
using Project1.Model;
using Android.Util;

namespace Project1.DbHelper
{
    public class DbHelper : SQLiteOpenHelper
    {
        private static string DB_PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private static string DB_NAME = "MyDB.db";
        private static int VERSION = 1;
        private Context context;

        public DbHelper(Context context) : base(context, DB_NAME, null, VERSION)
        {
            this.context = context;
        }

        private string GetSQLitePath()
        {
            return Path.Combine(DB_PATH, DB_NAME);
        }

        public override SQLiteDatabase WritableDatabase
        {
            get
            {
                return CreateSQLiteDB();
            }
        }

        private SQLiteDatabase CreateSQLiteDB()
        {
            SQLiteDatabase sqliteDB = null;
            string path = GetSQLitePath();
            Stream streamSQLite = null;
            FileStream streamWriter = null;
            Boolean isSQLiteInit = false;
            try
            {
                if (File.Exists(path))
                    isSQLiteInit = true;
                else
                {
                    streamSQLite = context.Resources.OpenRawResource(Resource.Raw.MyDB);
                    streamWriter = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    if(streamSQLite != null && streamWriter != null)
                    {
                        if (CopySQLiteDB(streamSQLite, streamWriter))
                            isSQLiteInit = true;
                    }
                }
                if (isSQLiteInit)
                    sqliteDB = SQLiteDatabase.OpenDatabase(path, null, DatabaseOpenFlags.OpenReadwrite);
            }
            catch { }
            return sqliteDB;
        }

        //...........****..........
        private bool CopySQLiteDB(Stream streamSQLite, FileStream streamWriter)
        {
            bool isSuccess = false;
            int length = 1024;
            Byte[] buffer = new Byte[length];
            try
            {
                int bytesRead = streamSQLite.Read(buffer, 0, length);
                while (bytesRead > 0) { 
                    streamWriter.Write(buffer, 0, bytesRead);
                    bytesRead = streamSQLite.Read(buffer, 0, length);
                }
                isSuccess = true;
            }
            catch
            {

            }
            finally
            {
                streamWriter.Close();
                streamSQLite.Close();
            }
            return isSuccess;
        }
        //...........****..........
        public override void OnCreate(SQLiteDatabase db)
        {
           
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            
        }


        //------Insert Score-----------------
        public void InsertScore(int score)
        {
            String query = $"INSERT INTO Ranking(Score) VALUES({score})";
            SQLiteDatabase db = this.WritableDatabase;
            db.ExecSQL(query);
        }


        public void InsertFlagScore(int score)
        {
            String query = $"INSERT INTO RankingFlag(Score) VALUES({score})";
            SQLiteDatabase db = this.WritableDatabase;
            db.ExecSQL(query);
        }



        public void InsertXamarinScore(int score)
        {
            String query = $"INSERT INTO RankingXamarin(Score) VALUES({score})";
            SQLiteDatabase db = this.WritableDatabase;
            db.ExecSQL(query);
        }

        //------------------------------------


        //Insert ScanText

        public List<ContentScanText> InsertScanText(ContentScanText scanText)
        {
            List<ContentScanText> lstQuestion = new List<ContentScanText>();
            // String query = $"INSERT INTO Question_IQ VALUES({iQQuestion})";
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                ContentValues vals = new ContentValues();
                vals.Put("Content", scanText.Content);
                vals.Put("Timer", scanText.Content);

                

                db.Insert("ScanText", null, vals);
            }
            catch { }
            return lstQuestion;

            //  db.ExecSQL(query);
        }
        public List<ContentScanText> GetContentScanText()
        {
            List<ContentScanText> lstQuestion = new List<ContentScanText>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            try
            {
                c = db.RawQuery($"SELECT * FROM ScanText", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Content = c.GetString(c.GetColumnIndex("Content"));
                    string Timer = c.GetString(c.GetColumnIndex("Timer"));
                 

           

                    ContentScanText iqquestion = new ContentScanText(Id, Content,Timer);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();
            }
            catch { }
            return lstQuestion;
        }

        public void DeleteScanText(string scantextId)
        {
            if (scantextId == null)
            {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            ICursor cursor = db.Query("ScanText",
                         new String[] { "Id", "Content","Timer" }, "Id=?", new string[] { scantextId }, null, null, null, null);

            if (cursor != null)
            {
                if (cursor.MoveToFirst())
                {
                    // update the row
                    db.Delete("ScanText", "Id=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }

        }







        //-------Insert Favorite English Word----------------

        public List<FavoriteWord> InsertFavoriteEnglishWord(FavoriteWord iQQuestion)
        {
            List<FavoriteWord> lstQuestion = new List<FavoriteWord>();
            // String query = $"INSERT INTO Question_IQ VALUES({iQQuestion})";
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                ContentValues vals = new ContentValues();
                vals.Put("NewWord", iQQuestion.NewWord);
                vals.Put("Mean", iQQuestion.Mean);
                vals.Put("Spelling", iQQuestion.Spelling);
                vals.Put("type", iQQuestion.type);
                vals.Put("Example", iQQuestion.Example);
                vals.Put("MeanEnglish", iQQuestion.MeanEnglish);
                vals.Put("Contribute", iQQuestion.Contribute);
                vals.Put("Level", iQQuestion.Level);

                db.Insert("FavoriteWord", null, vals);
            }
            catch { }
            return lstQuestion;

            //  db.ExecSQL(query);
        }

        //----------------------Get Favorite English Word-------------------------------
        public List<FavoriteWord> GetFavoriteEnglishWord()
        {
            List<FavoriteWord> lstQuestion = new List<FavoriteWord>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            try
            {
                c = db.RawQuery("SELECT * FROM FavoriteWord", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string NewWord = c.GetString(c.GetColumnIndex("NewWord"));
                    string Mean = c.GetString(c.GetColumnIndex("Mean"));
                    string Spelling = c.GetString(c.GetColumnIndex("Spelling"));

                    string type = c.GetString(c.GetColumnIndex("type"));
                    string Example = c.GetString(c.GetColumnIndex("Example"));
                    string MeanEnglish = c.GetString(c.GetColumnIndex("MeanEnglish"));
                    string Contribute = c.GetString(c.GetColumnIndex("Contribute"));
                    string Level = c.GetString(c.GetColumnIndex("Level"));

                    FavoriteWord iqquestion = new FavoriteWord(Id, NewWord, Mean, Spelling, type, Example, MeanEnglish, Contribute,Level);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch (Exception errorr)
            {
                // kh?i này th?c thi khi b?t ???c l?i
                Console.WriteLine("Có l?i r?i");
                Console.WriteLine(errorr.Message);
            }
            return lstQuestion;


        }
















        //-------InsertQuestionIq----------------

        public List<IQQuestion> InsertQuestionIQ(IQQuestion iQQuestion)
        {
            List<IQQuestion> lstQuestion = new List<IQQuestion>();
            // String query = $"INSERT INTO Question_IQ VALUES({iQQuestion})";
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                ContentValues vals = new ContentValues();
                vals.Put("Question", iQQuestion.Question);
                vals.Put("AnswerA", iQQuestion.AnswerA);
                vals.Put("AnswerB", iQQuestion.AnswerB);
                vals.Put("AnswerC", iQQuestion.AnswerC);
                vals.Put("AnswerD", iQQuestion.AnswerD);
                vals.Put("Image", iQQuestion.Image);
                vals.Put("CorrectAnswer", iQQuestion.CorrectAnswer);
                vals.Put("muc", iQQuestion.muc);

                db.Insert("UserQuestion_IQ", null, vals);
            }
            catch { }
            return lstQuestion;

            //  db.ExecSQL(query);
        }




        //Get All BY Search Name
        public List<IQQuestion> GetContactsBySearchName(string nameToSearch)
        {

            SQLiteDatabase db = this.ReadableDatabase;

            ICursor c = db.Query("UserQuestion_IQ", new string[] { "Id", "Question", "AnswerA", "AnswerB", "AnswerC","AnswerD","Image","CorrectAnswer","muc" }, "upper(Question) LIKE ?", new string[] { "%" + nameToSearch.ToUpper() + "%" }, null, null, null, null);

            var contacts = new List<IQQuestion>();

            while (c.MoveToNext())
            {
                contacts.Add(new IQQuestion
                {
                    Id = c.GetInt(0),
                    Question = c.GetString(1),
                    AnswerA = c.GetString(2),
                    AnswerB = c.GetString(3),
                    AnswerC = c.GetString(4),
                    AnswerD = c.GetString(5),
                    CorrectAnswer = c.GetString(6),
                    Image = c.GetString(7),
                    muc = c.GetString(8),
                });
            }

            c.Close();
            db.Close();

            return contacts;
        }


        //Get Detail Question
        public ICursor getContactIQQuestionById(int id)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor res = db.RawQuery("select * from UserQuestion_IQ where Id=" + id + "", null);
            return res;
        }

        //Update Existing contact
        public void UpdateIQQuestion(IQQuestion iQQuestion)
        {
            if (iQQuestion == null)
            {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            //Prepare content values
            ContentValues vals = new ContentValues();
        
            vals.Put("Question", iQQuestion.Question);
            vals.Put("AnswerA", iQQuestion.AnswerA);
            vals.Put("AnswerB", iQQuestion.AnswerB);
            vals.Put("AnswerC", iQQuestion.AnswerC);
            vals.Put("AnswerD", iQQuestion.AnswerD);
            vals.Put("Image", iQQuestion.Image);
            vals.Put("CorrectAnswer", iQQuestion.CorrectAnswer);
            vals.Put("muc", iQQuestion.muc);


            ICursor cursor = db.Query("UserQuestion_IQ",
                    new String[] { "Id", "Question", "AnswerA", "AnswerB", "AnswerC","AnswerD","CorrectAnswer","Image","muc" }, "Id=?", new string[] { iQQuestion.Id.ToString() }, null, null, null, null);

            if (cursor != null)
            {
                if (cursor.MoveToFirst())
                {
                    // update the row
                    db.Update("UserQuestion_IQ", vals, "Id=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }

        }

        //Delete Existing contact
        public void DeleteContact(string contactId)
        {
            if (contactId == null)
            {
                return;
            }

            //Obtain writable database
            SQLiteDatabase db = this.WritableDatabase;

            ICursor cursor = db.Query("UserQuestion_IQ",
                         new String[] { "Id", "Question", "AnswerA", "AnswerB", "AnswerC", "AnswerD", "CorrectAnswer", "Image", "muc" }, "Id=?", new string[] {contactId }, null, null, null, null);

            if (cursor != null)
            {
                if (cursor.MoveToFirst())
                {
                    // update the row
                    db.Delete("UserQuestion_IQ", "Id=?", new String[] { cursor.GetString(0) });
                }

                cursor.Close();
            }

        }


        //-------------------------------------------------------------



        //------GetRanking------------------------
        public List<Ranking> GetRanking()
        {
            List<Ranking> lstRanking = new List<Ranking>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            try
            {
                c = db.RawQuery("SELECT * FROM Ranking ORDER BY Score DESC", null);
                if (c == null) return null;
                c.MoveToNext();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    int Score = c.GetInt(c.GetColumnIndex("Score"));

                    Ranking ranking = new Model.Ranking(Id, Score);
                    lstRanking.Add(ranking);
                }
                while (c.MoveToNext());
                c.Close();
            }
            catch { }
            db.Close();
            return lstRanking;

        }

        //Get Flag Ranking
        public List<Ranking> GetFlagRanking()
        {
            List<Ranking> lstRanking = new List<Ranking>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            try
            {
                c = db.RawQuery("SELECT * FROM RankingFlag ORDER BY Score DESC", null);
                if (c == null) return null;
                c.MoveToNext();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    int Score = c.GetInt(c.GetColumnIndex("Score"));

                    Ranking ranking = new Model.Ranking(Id, Score);
                    lstRanking.Add(ranking);
                }
                while (c.MoveToNext());
                c.Close();
            }
            catch { }
            db.Close();
            return lstRanking;

        }

        //Get Xamarin Ranking
        public List<Ranking> GetXamarinRanking()
        {
            List<Ranking> lstRanking = new List<Ranking>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            try
            {
                c = db.RawQuery("SELECT * FROM RankingXamarin ORDER BY Score DESC", null);
                if (c == null) return null;
                c.MoveToNext();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    int Score = c.GetInt(c.GetColumnIndex("Score"));

                    Ranking ranking = new Model.Ranking(Id, Score);
                    lstRanking.Add(ranking);
                }
                while (c.MoveToNext());
                c.Close();
            }
            catch { }
            db.Close();
            return lstRanking;

        }



        //-------------------------------------------------------------


        //----------------------Get Comunication English-------------------------------
        public List<ComunicationEnglishModel> GetComunicationEnglish()
        {
            List<ComunicationEnglishModel> lstQuestion = new List<ComunicationEnglishModel>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            try
            {
                c = db.RawQuery($"SELECT * FROM EnglishComunication", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Tittle = c.GetString(c.GetColumnIndex("Tittle"));
                    string Content1 = c.GetString(c.GetColumnIndex("Content1"));
                    string Content2 = c.GetString(c.GetColumnIndex("Content2"));

                    string Content3 = c.GetString(c.GetColumnIndex("Content3"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    ComunicationEnglishModel iqquestion = new ComunicationEnglishModel(Id, Tittle, Content1, Content2, Content3, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;


        }


        //----------------------Get Xamarin Interview Quesion-------------------------------
        public List<XamarinInterview> GetOOPInterviewQuestions()
        {
            List<XamarinInterview> lstQuestion = new List<XamarinInterview>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            try
            {
                c = db.RawQuery($"SELECT * FROM XamarinInterview where muc = 'OOP'", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Tittle = c.GetString(c.GetColumnIndex("Tittle"));
                    string Content1 = c.GetString(c.GetColumnIndex("Content1"));
                    string Content2 = c.GetString(c.GetColumnIndex("Content2"));

                    string Content3 = c.GetString(c.GetColumnIndex("Content3"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    XamarinInterview iqquestion = new XamarinInterview(Id, Tittle, Content1, Content2, Content3, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;


        }



        //----------------------Get Xamarin Interview Quesion-------------------------------
        public List<XamarinInterview> GetXamarinInterviewQuestions()
        {
            List<XamarinInterview> lstQuestion = new List<XamarinInterview>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            try
            {
                c = db.RawQuery($"SELECT * FROM XamarinInterview where muc = 'normal'", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Tittle = c.GetString(c.GetColumnIndex("Tittle"));
                    string Content1 = c.GetString(c.GetColumnIndex("Content1"));
                    string Content2 = c.GetString(c.GetColumnIndex("Content2"));
                  
                    string Content3 = c.GetString(c.GetColumnIndex("Content3"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    XamarinInterview iqquestion = new XamarinInterview(Id, Tittle,Content1,Content2,Content3,muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;


        }

        //----------------------Get Xamarin Interview Quesion-------------------------------
        public List<XamarinInterview> GetXamarinAdvancedQuestions()
        {
            List<XamarinInterview> lstQuestion = new List<XamarinInterview>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            try
            {
                c = db.RawQuery($"SELECT * FROM XamarinInterview where muc = 'android' ", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Tittle = c.GetString(c.GetColumnIndex("Tittle"));
                    string Content1 = c.GetString(c.GetColumnIndex("Content1"));
                    string Content2 = c.GetString(c.GetColumnIndex("Content2"));

                    string Content3 = c.GetString(c.GetColumnIndex("Content3"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));
                    XamarinInterview iqquestion = new XamarinInterview(Id, Tittle, Content1, Content2, Content3,muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;


        }











        //----User Add Question
        public List<IQQuestion> GetIQQuestions()
        {
            List<IQQuestion> lstQuestion = new List<IQQuestion>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            try
            {
                c = db.RawQuery($"SELECT * FROM UserQuestion_IQ", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Question = c.GetString(c.GetColumnIndex("Question"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));

                    IQQuestion iqquestion = new IQQuestion(Id, Question, Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;
        }




        public List<IQQuestion> GetUserIQQuestionMode(string mode)
        {
            List<IQQuestion> lstQuestion = new List<IQQuestion>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            if (mode.Equals(Common.Common.MODE.EASY.ToString()))
                limit = Common.Common.EASY_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.MEDIUM.ToString()))
                limit = Common.Common.MEDIUM_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.HARD.ToString()))
                limit = Common.Common.HARD_MODE_NUM;
            else
                limit = Common.Common.HARDEST_MODE_NUM;
            try
            {
                c = db.RawQuery($"SELECT * FROM UserQuestion_IQ ORDER BY Random() LIMIT {limit}", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Question = c.GetString(c.GetColumnIndex("Question"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));

                    IQQuestion iqquestion = new IQQuestion(Id, Question, Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;
        }




        //----------------------------------------------------------------------------------
        public List<IQQuestion> GetIQQuestionMode(string mode)
        {
            List<IQQuestion> lstQuestion = new List<IQQuestion>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            if (mode.Equals(Common.Common.MODE.EASY.ToString()))
                limit = Common.Common.EASY_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.MEDIUM.ToString()))
                limit = Common.Common.MEDIUM_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.HARD.ToString()))
                limit = Common.Common.HARD_MODE_NUM;
            else
                limit = Common.Common.HARDEST_MODE_NUM;
            try
            {
                c = db.RawQuery($"SELECT * FROM Question_IQ ORDER BY Random() LIMIT {limit}", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Question = c.GetString(c.GetColumnIndex("Question"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));
                  
                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));

                    IQQuestion iqquestion = new IQQuestion(Id, Question,Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer,muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;
        }

        public List<FlagQuestion> GetQuestionMode(string mode)
        {
            List<FlagQuestion> lstQuestion = new List<FlagQuestion>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            if (mode.Equals(Common.Common.MODE.EASY.ToString()))
                limit = Common.Common.EASY_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.MEDIUM.ToString()))
                limit = Common.Common.MEDIUM_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.HARD.ToString()))
                limit = Common.Common.HARD_MODE_NUM;
            else
                limit = Common.Common.HARDEST_MODE_NUM;
            try
            {
                c = db.RawQuery($"SELECT * FROM Question ORDER BY Random() LIMIT {limit}",null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("ID"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    

                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                   
                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));
                  //  string Question = c.GetString(c.GetColumnIndex("QS"));

                    FlagQuestion question = new FlagQuestion(Id,Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer);
                    lstQuestion.Add(question);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;
        }



        //----------------------GetQuesion-------------------------------
        public List<QuestionXamrin> GetEnglishQuestionMode(string mode)
        {
            List<QuestionXamrin> lstQuestion = new List<QuestionXamrin>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            if (mode.Equals(Common.Common.MODE.EASY.ToString()))
                limit = Common.Common.EASY_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.MEDIUM.ToString()))
                limit = Common.Common.MEDIUM_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.HARD.ToString()))
                limit = Common.Common.HARD_MODE_NUM;
            else
                limit = Common.Common.HARDEST_MODE_NUM;
            try
            {
                c = db.RawQuery($"SELECT * FROM TRAC_NGHIEM ORDER BY Random() LIMIT {limit}", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Question = c.GetString(c.GetColumnIndex("Question"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));

                    QuestionXamrin iqquestion = new QuestionXamrin(Id, Question, Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;


        }



        public List<QuestionXamrin> GetXamarinQuestionMode(string mode)
        {
            List<QuestionXamrin> lstQuestion = new List<QuestionXamrin>();
            SQLiteDatabase db = this.WritableDatabase;
            ICursor c;
            int limit = 0;
            if (mode.Equals(Common.Common.MODE.EASY.ToString()))
                limit = Common.Common.EASY_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.MEDIUM.ToString()))
                limit = Common.Common.MEDIUM_MODE_NUM;
            else if (mode.Equals(Common.Common.MODE.HARD.ToString()))
                limit = Common.Common.HARD_MODE_NUM;
            else
                limit = Common.Common.HARDEST_MODE_NUM;
            try
            {
                c = db.RawQuery($"SELECT * FROM Xamarin ORDER BY Random() LIMIT {limit}", null);
                if (c == null) return null;
                c.MoveToFirst();
                do
                {
                    int Id = c.GetInt(c.GetColumnIndex("Id"));
                    string Question = c.GetString(c.GetColumnIndex("Question"));
                    string Image = c.GetString(c.GetColumnIndex("Image"));
                    string AnswerA = c.GetString(c.GetColumnIndex("AnswerA"));
                    string AnswerB = c.GetString(c.GetColumnIndex("AnswerB"));
                    string AnswerC = c.GetString(c.GetColumnIndex("AnswerC"));
                    string AnswerD = c.GetString(c.GetColumnIndex("AnswerD"));
                    string muc = c.GetString(c.GetColumnIndex("muc"));

                    string CorrectAnswer = c.GetString(c.GetColumnIndex("CorrectAnswer"));

                    QuestionXamrin iqquestion = new QuestionXamrin(Id, Question, Image, AnswerA, AnswerB, AnswerC, AnswerD, CorrectAnswer, muc);
                    lstQuestion.Add(iqquestion);

                }
                while (c.MoveToNext());
                c.Close();


            }
            catch { }
            return lstQuestion;
        }



        //Update 2.0
        //public int GetPlayCount(int Level)
        //{
        //    int result = 0;
        //    SQLiteDatabase db = this.WritableDatabase;
        //    ICursor c;
        //    try
        //    {
        //        c = db.RawQuery($"SELECT PlayCount FROM UserPlayCount WHERE Level={Level}",null);
        //        if (c == null) return 0;
        //        c.MoveToFirst();
        //        do
        //        {
        //            result = c.GetInt(c.GetColumnIndex("PlayCount"));
        //        } while (c.MoveToNext());
        //        c.Close();

        //    }catch(Exception e) { }
        //    return result;
        //}

        //public void UpdatePlayCount(int Level,int PlayCount)
        //{
        //    string query = $"UPDATE UserPlayCount SET PlayCount={PlayCount} WHERE Level={Level}";
        //    SQLiteDatabase db = this.WritableDatabase;
        //    db.ExecSQL(query);
        //}


    }
}