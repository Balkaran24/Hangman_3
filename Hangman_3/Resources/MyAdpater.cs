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

namespace Hangman_3.Resources
{
    public class MyAdpater : BaseAdapter<HangmanScore>
    {
        private readonly Activity context;
        private readonly List<HangmanScore> mItems;

        public MyAdpater(Activity context, List<HangmanScore> items)
        {
            this.mItems = items;
            this.context = context;
        }



        public override int Count
        {
            get { return mItems.Count; }

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override HangmanScore this[int position]
        {
            get { return mItems[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var row = convertView;


            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ListViewRow , null, false);
            }

            // Set the txtRowName.Text which is in the listview_row layout to the Players Name
            TextView txtRowName = row.FindViewById<TextView>(Resource.Id.txtRowName);
            txtRowName.Text = mItems[position].Name ;

            // Set the txtRowName.Text in the  listview_row to the Players score
            TextView txtRowScore = row.FindViewById<TextView>(Resource.Id.txtRowScore);
            txtRowScore.Text = mItems[position].Score.ToString();

            return row;


        }
    }
}