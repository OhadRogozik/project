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
    public class Scores
    {
        private string name;
        private string time;
        private int score;
        public Scores(string n, string t, int s)
        {
            this.name = n;
            this.time = t;
            this.score = s;
        }
        public string getName()
        {
            return this.name;
        }
        public string getTime()
        {
            return this.time;
        }
        public int getScore()
        {
            return this.score;
        }
        public void setName(string n)
        {
            this.name = n;
        }
        public void setTime(string t)
        {
            this.time = t;
        }
        public void setScore(int s)
        {
            this.score = s;
        }

    }
}