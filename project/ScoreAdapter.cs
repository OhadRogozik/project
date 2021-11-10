using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project
{
    public class ScoreAdapter : BaseAdapter<Scores>
    {
        Context context;
        List<Scores> objects;
        public ScoreAdapter(Context context, List<Scores> objects)
        {
            this.context = context;
            this.objects = objects;
        }

        public override Scores this[int position]
        {
            get { return this.objects[position]; }
        }

        public override int Count
        {
            get { return this.objects.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Android.Views.LayoutInflater layoutInflater = ((Activity)context).LayoutInflater;
            Android.Views.View view = layoutInflater.Inflate(Resource.Layout.custom_layout, parent, false);
            TextView tv1 = view.FindViewById<TextView>(Resource.Id.tv1);
            TextView tv2 = view.FindViewById<TextView>(Resource.Id.tv2);
            TextView tv3 = view.FindViewById<TextView>(Resource.Id.tv3);
            Scores temp = objects[position];
            if (temp != null)
            {
                tv1.Text = "" + temp.getName();
                tv2.Text = "" + temp.getTime();
                tv3.Text = "" + temp.getScore();
            }
            return view;
        }
    }
}