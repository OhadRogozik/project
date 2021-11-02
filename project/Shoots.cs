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
    public class Shoots
    {
        private int x;
        private int y;
        private int w;
        private int h;
        private string direction;
        public Shoots(int x,int y, int w, int h, string d)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.direction = d;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public int getW()
        {
            return this.w;
        }
        public int getH()
        {
            return this.h;
        }
        public string getDirection()
        {
            return this.direction;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void setW(int w)
        {
            this.w = w;
        }
        public void setH(int h)
        {
            this.h = h;
        }
        public void setDirection(string d)
        {
            this.direction = d;
        }
    }
}