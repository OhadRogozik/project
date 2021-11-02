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
    public class EnemyP1 : Enemy
    {
        private int speed;
        private int hp;
        private int x;
        private int y;
        public EnemyP1(int speed, int hp,int x,int y):base(speed,hp,x,y)
        {
            
        }
    }
}