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

namespace project
{
    public class Enemy
    {
        protected int speed;
        protected int hp;
        protected int x;
        protected int y;
        public Enemy(int speed,int hp,int x,int y)
        {
            this.speed = speed;
            this.hp = hp;
            this.x = x;
            this.y = y;
        }
        public int getSpeed()
        {
            return this.speed;
        }
        public int getHP()
        {
            return this.hp;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public void setSpeed(int s)
        {
            this.speed = s;
        }
        public void setHP(int s)
        {
            this.hp = s;
        }
        public void setX(int s)
        {
            this.x = s;
        }
        public void setY(int s)
        {
            this.y = s;
        }
    }
}