﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Hangman_3.Resources;

namespace Hangman_3
{
    [Activity(Label = "Delete Record")]
    public class Del_entry : Activity
    {
        List<HangmanScore > List_All;
        private Button btn_Delete;
        private Spinner spinner_select;
        private Button btn_Home_Page;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Del_Rec_Layout);
            MyConnection myConnectionClass = new MyConnection();
            List_All = myConnectionClass.ViewAll();

            btn_Home_Page = FindViewById<Button>(Resource.Id.btn_Home_Page);
            btn_Home_Page.Click += btn_Home_Page_Click;

            spinner_select = FindViewById<Spinner>(Resource.Id.spinner_select);
            Hangman_3.Resources.MyAdpater  da = new Resources.MyAdpater(this, List_All);

            spinner_select.Adapter = da;

            spinner_select.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_select_ItemSelected);

            btn_Delete = FindViewById<Button>(Resource.Id.btn_Delete);
            btn_Delete.Click += btn_Delete_Click;
            btn_Delete.Enabled = false;


        }

        private void btn_Home_Page_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var cc = new MyConnection();
            cc.DeletePlayer(Hangman_Game.Id);
            List_All = cc.ViewAll();


            var da = new Resources.MyAdpater(this, List_All);

            spinner_select.Adapter = da;
        }

        private void spinner_select_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {


            Spinner spinner = (Spinner)sender;
            Hangman_Game.Id = this.List_All.ElementAt(e.Position).Id;
            btn_Delete.Enabled = true;

        }



    }
}