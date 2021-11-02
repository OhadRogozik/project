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
    public class EnemyP2 : Enemy
    {
        private int speed;
        private int hp;
        private int x;
        private int y;
        private int movement;
        public EnemyP2(int speed, int hp, int x, int y,int movement) : base(speed, hp,x,y)
        {
            this.movement = movement;
        }
        public int getMovement()
        {
            return this.movement;
        }
        public void setMovement(int s)
        {
            this.movement = s;
        }
    }
}