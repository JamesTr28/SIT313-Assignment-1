using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Ass1_313_
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> scoreList = new List<string>() ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.content_main);
            var startBut = FindViewById<Button>(Resource.Id.start);
            var scoreBut = FindViewById<Button>(Resource.Id.scoreBoard);



            startBut.Click += (object sender, EventArgs e) =>
            {
                Intent quizActivity = new Intent(this, typeof(QuizActivity));
                StartActivity(quizActivity);

            };

            string score = Intent.GetStringExtra("score" ?? "Not available");
            string highestscore = Intent.GetStringExtra("highestscore" ?? "Not available");

            if (score != null) scoreList.Add(score);
            if (highestscore != null) scoreList.Add(highestscore);

            scoreBut.Click += (s, e) =>
            {
                Intent scoreActivity = new Intent(this, typeof(ScoreBoard));
                scoreActivity.PutStringArrayListExtra("score_List", scoreList);

                
                StartActivity(scoreActivity);
            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

