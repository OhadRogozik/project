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
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        ListView lv;
        ScoreAdapter adapter;
        int posit;
        public static List<Scores> list { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);
            lv = (ListView)FindViewById(Resource.Id.lv1);
            list = new List<Scores>();
            list.Add(new Scores("Ohad", 2 + ":" + 31, 100));
            list.Add(new Scores("Yaron", 3 + ":" + 25, 60));
            list.Add(new Scores("Ofra", 1 + ":" + 56, 73));
            adapter = new ScoreAdapter(this, list);
            lv = (ListView)FindViewById(Resource.Id.lv1);
            lv.Adapter = adapter;
            lv.ItemClick += Lv_ItemClick;
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            posit = e.Position;
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Delete");
            builder.SetMessage("are you sure you want to delete?");
            builder.SetCancelable(true);
            builder.SetPositiveButton("yes", OkAction);
            builder.SetNegativeButton("cancel", CancelAction);
            AlertDialog dialog = builder.Create();
            dialog.Show();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Action Canceld", ToastLength.Short).Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            Activity2.list.RemoveAt(posit);
            adapter.NotifyDataSetChanged();
            Toast.MakeText(this, "Action Confirm", ToastLength.Short).Show();
        }
    }
}