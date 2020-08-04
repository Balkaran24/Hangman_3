using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Hangman_3.Resources;

namespace Hangman_3
{
    [Activity(Label = "Hangman Game", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btn_New_Game;
        private Button btn_High_Score;




        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainPage);



            btn_New_Game = FindViewById<Button>(Resource.Id.btn_New_Game);
            btn_New_Game.Click += btn_New_Game_Click;

            btn_High_Score = FindViewById<Button>(Resource.Id.btn_High_Score);
            btn_High_Score.Click += btn_High_Score_Click;

            Button btn_Delete = FindViewById<Button>(Resource.Id.btn_Delete);
            btn_Delete.Click += btn_Delete_Click;

            Button btn_Exit = FindViewById<Button>(Resource.Id.btn_Exit);
            btn_Exit.Click += btn_Exit_Click;



        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Del_entry ));
        }






        private void btn_High_Score_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HgScr ));
        }

        private void btn_New_Game_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(NewPlyr));
        }
    }
}

