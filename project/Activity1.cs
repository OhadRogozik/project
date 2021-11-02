using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace project
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        Game board;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            board = new Game(this);
            board.Background = new BitmapDrawable(Resources, BitmapFactory.DecodeResource(Resources, Resource.Drawable.back1));
            SetContentView(board);

        }
    }
}