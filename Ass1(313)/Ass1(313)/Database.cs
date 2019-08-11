using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Cursor = Android.Database.ICursor;
using System.Collections.Generic;

namespace Ass1_313_
{
    public class Database : SQLiteOpenHelper
    {
        private static int DATABASE_VERSION = 1;
        // Database Name
        private static string DATABASE_NAME = "theQuiz1";
        // tasks table name
        private static string TABLE_QUEST = "quiz1";
        // tasks Table Columns names
        private static string KEY_ID = "id";
        private static string KEY_QUES = "question";
        private static string KEY_ANSWER = "answer"; //correct option
        private static string KEY_OPTA = "opta"; //option a
        private static string KEY_OPTB = "optb"; //option b
        private static string KEY_OPTC = "optc"; //option c
        private SQLiteDatabase dbase;

        public Database(Context context) : base(context, DATABASE_NAME, null, DATABASE_VERSION)
        {
        }



        public override void OnCreate(SQLiteDatabase db)
        {
            //base.OnCreate (db);
            dbase = db;
            string sql = "CREATE TABLE IF NOT EXISTS " + TABLE_QUEST + " ( "
                + KEY_ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " + KEY_QUES
                + " TEXT, " + KEY_ANSWER + " TEXT, " + KEY_OPTA + " TEXT, "
                + KEY_OPTB + " TEXT, " + KEY_OPTC + " TEXT)";
            db.ExecSQL(sql);
            addQuestions();
            //db.close();
        }


        private void addQuestions()
        {
            Question q1 = new Question("Who is the first black president of USA?", "Teddy Roosevelt", "Barrack Obama", "Chuck Norris", "Barrack Obama");
            this.addQuestion(q1);
            Question q2 = new Question("Where is Melbourne located?", "NSW", "NT", "VIC", "VIC");
            this.addQuestion(q2);
            Question q3 = new Question("who is CEO of the Tesla?", "Elon Musk", "Bill Gates", "Jeff Bezos", "Elon Musk");
            this.addQuestion(q3);
            Question q4 = new Question("The country that has the highest population in the world is?", "India", "USA", "China", "China");
            this.addQuestion(q4);
            Question q5 = new Question("When did the World War 2 end?", "6/1975", "9/1945", "8/1945", "9/1945");
            this.addQuestion(q5);
            Question q6 = new Question("Who is the 1st president of USA?", "George Washington", "Abraham Lincoln", "JFL", "George Washington");
            this.addQuestion(q6);
            Question q7 = new Question("How many states does Australia have?", "3", "6", "8", "6");
            this.addQuestion(q7);
            Question q8 = new Question("What year did Leonardo DiCaprio win Oscar?", "2012", "2014", "2016", "2016");
            this.addQuestion(q8);
            Question q9 = new Question("When was the 1st Avatar movie release?", "2007", "2009", "2012", "2009");
            this.addQuestion(q9);
            Question q10 = new Question("What does Xamarin.Form support?", "Android", "iOS", "all answer is true", "all answer is true");
            this.addQuestion(q10);
        }


        public override void OnUpgrade(SQLiteDatabase db, int oldV, int newV)
        {
            //base.OnUpgrade (db, oldV, newV);
            // Drop older table if existed
            db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_QUEST);
            // Create tables again
            OnCreate(db);
        }

        // Adding new question
        public void addQuestion(Question quest)
        {
            //SQLiteDatabase db = this.getWritableDatabase();
            ContentValues values = new ContentValues();
            values.Put(KEY_QUES, quest.getQUESTION());
            values.Put(KEY_ANSWER, quest.getANSWER());
            values.Put(KEY_OPTA, quest.getOPTA());
            values.Put(KEY_OPTB, quest.getOPTB());
            values.Put(KEY_OPTC, quest.getOPTC());
            // Inserting Row
            dbase.Insert(TABLE_QUEST, null, values);
        }


        public List<Question> getAllQuestions()
        {
            List<Question> quesList = new List<Question>();
            // Select All Query
            string selectQuery = "SELECT  * FROM " + TABLE_QUEST;
            dbase = this.ReadableDatabase;
            Cursor cursor = dbase.RawQuery(selectQuery, null);
            // looping through all rows and adding to list
            if (cursor.MoveToFirst())
            {
                do
                {
                    Question quest = new Question();
                    quest.setID(cursor.GetInt(0));
                    quest.setQUESTION(cursor.GetString(1));
                    quest.setANSWER(cursor.GetString(2));
                    quest.setOPTA(cursor.GetString(3));
                    quest.setOPTB(cursor.GetString(4));
                    quest.setOPTC(cursor.GetString(5));
                    quesList.Add(quest);
                } while (cursor.MoveToNext());
            }
            // return quest list
            return quesList;
        }
        public int rowcount()
        {
            int row = 0;
            string selectQuery = "SELECT  * FROM " + TABLE_QUEST;
            SQLiteDatabase db = this.WritableDatabase;
            Cursor cursor = db.RawQuery(selectQuery, null);
            row = cursor.Count;
            return row;
        }

    }
}

