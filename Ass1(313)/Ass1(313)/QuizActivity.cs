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

namespace Ass1_313_
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : Activity
    {

        List<Question> quesList;
        int score = 0;
        int qid = 0;
        Question currentQ;
        TextView txtQuestion, txtScore;
        RadioButton rda, rdb, rdc;
        Button butNext;
        string answer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application 
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QuizLayout);
            Database db = new Database(this);
            quesList = db.getAllQuestions();


            txtScore = (TextView)FindViewById(Resource.Id.textView2);
            txtQuestion = (TextView)FindViewById(Resource.Id.textView1);
            rda = (RadioButton)FindViewById(Resource.Id.radio0);
            rdb = (RadioButton)FindViewById(Resource.Id.radio1);
            rdc = (RadioButton)FindViewById(Resource.Id.radio2);
            butNext = (Button)FindViewById(Resource.Id.button1);
            setQuestionView();

            butNext.Click += (object sender, System.EventArgs e) =>
            {
                if ((rdc.Checked && answer.Equals(rdc.Text)) || (rdb.Checked && answer.Equals(rdb.Text)) || (rda.Checked && answer.Equals(rda.Text)))
                {
                    score++;
                    if (qid < 10)
                    {
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alert = dialog.Create();
                        alert.SetTitle("Correct Answer");
                        alert.SetMessage("Goodjob! Lets move to next one");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            setQuestionView();
                        });
                        alert.Show();

                        txtScore.Text = $"Score: {score}";
                    }
                    else
                    {
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alert = dialog.Create();
                        alert.SetTitle("Correct Answer");
                        alert.SetMessage("Congratulation! You have answered all the questions and reached the highest score: 10. Now you can go back to Menu and see your high score!");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            Intent intent = new Intent(this, typeof(MainActivity));

                            intent.PutExtra("highestscore", score.ToString());
                            
                            StartActivity(intent);
                        });
                        alert.Show();
                    }

                }
                else
                {

                    Intent wrongChoice = new Intent(this, typeof(WrongAnswer));
                    wrongChoice.PutExtra("finalscore", score.ToString());
                    wrongChoice.PutExtra("correctanswer", answer);
                    StartActivity(wrongChoice);
                }

            };

        }

        private void setQuestionView()
        {
            currentQ = quesList[qid];
            txtQuestion.Text = currentQ.getQUESTION();
            rda.Text = currentQ.getOPTA();
            rdb.Text = currentQ.getOPTB();
            rdc.Text = currentQ.getOPTC();
            answer = currentQ.getANSWER();


            qid++;
        }
    }
}