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
    [Activity(Label = "ScoreBoard")]
    public class ScoreBoard : ListActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var score_list = Intent.Extras.GetStringArrayList("score_List") ?? new string[0];

            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, score_list) ;

        }
    }
}