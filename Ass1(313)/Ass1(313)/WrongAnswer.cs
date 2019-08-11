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
    [Activity(Label = "WrongAnswer")]
    public class WrongAnswer : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WrongAnswer);

            // Create your application here
            var correctAnswer = FindViewById<TextView>(Resource.Id.answer);
            var userscore = FindViewById<TextView>(Resource.Id.score);
            var backBut = FindViewById<Button>(Resource.Id.back);

            string Answer = Intent.GetStringExtra("correctanswer" ?? "Not available");
            string Score = Intent.GetStringExtra("finalscore" ?? "Not available");

            correctAnswer.Text = $"Correct answer is: {Answer}";
            userscore.Text = $"Final Score: {Score}";

            backBut.Click += (object sender, EventArgs e) =>
            {
                Intent backMenu = new Intent(this, typeof(MainActivity));

                backMenu.PutExtra("score", Score);
                StartActivity(backMenu);
            };



        }
    }
}