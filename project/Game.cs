using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace project
{
    public class Game:View
    {
        private Context context;
        private float x1, y1;
        private Paint p1, p2, p3;
        int cH;
        int cW;
        bool b;
        List<Shoots> shootsList;
        List<Enemy> enemyList;
        public Game(Context context) : base(context)
        {
            cH = 0;
            cW = 0;
            b = true;
            shootsList = new List<Shoots>();
            enemyList = new List<Enemy>();
            this.p1 = new Paint();
            this.p1.Color = Color.Black;
            this.p1.TextSize = 40;
            this.p2 = new Paint();
            this.p2.Color = Color.Gray;
            this.p3 = new Paint();
            this.p3.Color = Color.Red;
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            cH = canvas.Height;
            cW = canvas.Width;
            if (b)
            {
                x1 = canvas.Width / 2-25;
                y1 = canvas.Height / 2-35;
                b = false;
                enemyList.Add(new Enemy(1, 2, 20, 20));
            }
            canvas.DrawRect(x1,y1,x1+70,y1+70,p3);//character
            for (int i = 0; i < enemyList.Count; i++)
            {
                canvas.DrawRect(enemyList[i].getX(), enemyList[i].getY(), enemyList[i].getX() + 50, enemyList[i].getY() + 50, p3);//enemy
            }
            //-----------------------------SHOOTING----------------------------------------
            canvas.DrawText("shooting",10, canvas.Height - 200, p1);//title
            canvas.DrawRect(10, canvas.Height - 110, 70, canvas.Height - 70, p2);//left
            canvas.DrawRect(110, canvas.Height - 110, 170, canvas.Height - 70, p2);//right
            canvas.DrawRect(70, canvas.Height - 70, 110, canvas.Height-10, p2);//down
            canvas.DrawRect(70, canvas.Height - 170, 110, canvas.Height - 110, p2);//up
            //-----------------------------MOVING-------------------------------------------
            canvas.DrawText("moving", canvas.Width-150, canvas.Height - 200, p1);//title
            canvas.DrawRect(canvas.Width - 170, canvas.Height - 110, canvas.Width - 110, canvas.Height - 70, p2);//left
            canvas.DrawRect(canvas.Width - 70, canvas.Height - 110, canvas.Width-10, canvas.Height - 70, p2);//right
            canvas.DrawRect(canvas.Width - 110, canvas.Height - 70, canvas.Width - 70, canvas.Height-10, p2);//down
            canvas.DrawRect(canvas.Width - 110, canvas.Height - 170, canvas.Width - 70, canvas.Height - 110, p2);//up
            //-----------------------------THE_SHOTS------------------------------------------
            for (int i = 0; i < shootsList.Count; i++)
            {
                canvas.DrawRect(shootsList[i].getX(), shootsList[i].getY(), shootsList[i].getX()+ shootsList[i].getW(), shootsList[i].getY()+ shootsList[i].getH(), p2);
                if(shootsList[i].getDirection().Equals("left"))
                {
                    shootsList[i].setX(shootsList[i].getX() - 3);
                }
                else if (shootsList[i].getDirection().Equals("right"))
                {
                    shootsList[i].setX(shootsList[i].getX() + 3);
                }
                else if (shootsList[i].getDirection().Equals("down"))
                {
                    shootsList[i].setY(shootsList[i].getY() + 3);
                }
                else if (shootsList[i].getDirection().Equals("up"))
                {
                    shootsList[i].setY(shootsList[i].getY() - 3);
                }

                if(shootsList[i].getX()<0|| shootsList[i].getX()>canvas.Width)
                {
                    shootsList.RemoveAt(i);
                }
                else if (shootsList[i].getY() < 0 || shootsList[i].getY() > canvas.Height)
                {
                    shootsList.RemoveAt(i);
                }
            }
            //-----------------------------ENEMY_MOVEMENT------------------------------------------
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (x1 - enemyList[i].getX() > 0)
                {
                    if(y1 - enemyList[i].getY() > 0)
                    {
                        if(x1 - enemyList[i].getX() > y1 - enemyList[i].getY())
                        {
                            enemyList[i].setX(enemyList[i].getX() + enemyList[i].getSpeed());
                        }
                        else
                        {
                            enemyList[i].setY(enemyList[i].getY() + enemyList[i].getSpeed());
                        }
                    }
                    else
                    {
                        if (x1 - enemyList[i].getX() > enemyList[i].getY()-y1)
                        {
                            enemyList[i].setX(enemyList[i].getX() + enemyList[i].getSpeed());
                        }
                        else
                        {
                            enemyList[i].setY(enemyList[i].getY() - enemyList[i].getSpeed());
                        }
                    }
                }
                else
                {
                    if (y1 - enemyList[i].getY() > 0)
                    {
                        if(enemyList[i].getX()-x1 > y1 - enemyList[i].getY())
                        {
                            enemyList[i].setX(enemyList[i].getX() - enemyList[i].getSpeed());
                        }
                        else
                        {
                            enemyList[i].setY(enemyList[i].getY() + enemyList[i].getSpeed());
                        }
                    }
                    else
                    {
                        if (x1-enemyList[i].getX() > y1 - enemyList[i].getY())
                        {
                            enemyList[i].setX(enemyList[i].getX() - enemyList[i].getSpeed());
                        }
                        else
                        {
                            enemyList[i].setY(enemyList[i].getY() - enemyList[i].getSpeed());
                        }
                    }
                }
            }
            didHit();
            Invalidate();
        }

        public void didHit()
        {
            for (int i = 0; i < shootsList.Count; i++)
            {
                for (int j = 0; j < enemyList.Count; j++)
                {
                    if(shootsList[i].getX()>enemyList[j].getX()-15 && shootsList[i].getX() < enemyList[j].getX()+65)
                    {
                        if(shootsList[i].getY() > enemyList[j].getY()-15 && shootsList[i].getY() < enemyList[j].getY() + 65)
                        {
                            shootsList.RemoveAt(i);
                            enemyList[j].setHP(enemyList[j].getHP()-1);
                            if (enemyList[j].getHP()==0)
                            {
                                enemyList.RemoveAt(j);
                                enemyList.Add(new Enemy(1, 2, 20, 20));
                            }
                        }
                    }
                }
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                //shooting
                if (e.GetX() >= 10 && e.GetX() < 70)
                {
                    if (e.GetY() >= cH - 110 && e.GetY() < cH - 70)
                    {
                        //left
                        Shoots s1 = new Shoots((int)x1-10, (int)y1+28,15,15,"left");
                        shootsList.Add(s1);
                        Invalidate();
                    }
                }
                else if (e.GetX() >= 110 && e.GetX() < 170)
                {
                    if (e.GetY() >= cH - 110 && e.GetY() < cH - 70)
                    {
                        //right
                        Shoots s1 = new Shoots((int)x1+60, (int)y1+28, 15, 15, "right");
                        shootsList.Add(s1);
                        Invalidate();
                    }
                }
                else if (e.GetX() >= 70 && e.GetX() < 110)
                {
                    if (e.GetY() >= cH - 70 && e.GetY() < cH - 10)
                    {
                        //down
                        Shoots s1 = new Shoots((int)x1+28, (int)y1+60, 15, 15, "down");
                        shootsList.Add(s1);
                        Invalidate();
                    }
                    else if (e.GetY() >= cH - 170 && e.GetY() < cH - 110)
                    {
                        //up
                        Shoots s1 = new Shoots((int)x1+28, (int)y1-10, 15, 15, "up");
                        shootsList.Add(s1);
                        Invalidate();
                    }
                }

                //moving
                if (e.GetX() >= cW - 170 && e.GetX() < cW - 110)
                {
                    if (e.GetY() >= cH - 110 && e.GetY() < cH - 70)
                    {
                        //left
                        if(x1>20)
                        {
                            x1 = x1 - 20;
                        }
                        Invalidate();
                    }
                }
                else if (e.GetX() >= cW - 70 && e.GetX() < cW - 10)
                {
                    if (e.GetY() >= cH - 110 && e.GetY() < cH - 70)
                    {
                        //right
                        if (x1 < cW-90)
                        {
                            x1 = x1 + 20;
                        }
                        Invalidate();
                    }
                }
                else if (e.GetX() >= cW - 110 && e.GetX() < cW - 70)
                {
                    if (e.GetY() >= cH - 70 && e.GetY() < cH - 10)
                    {
                        //down
                        if(y1<cH-90)
                        {
                            y1 = y1 + 20;
                        }
                        Invalidate();
                    }
                    else if (e.GetY() >= cH - 170 && e.GetY() < cH - 110)
                    {
                        //up
                        if(y1>20)
                        {
                            y1 = y1 - 20;
                        }
                        Invalidate();
                    }
                }
            }
            return true;
        }
    }
}