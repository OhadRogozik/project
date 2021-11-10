 using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System;

namespace project
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn1, btn2;
        Dialog d;
        EditText etUserName;
        TextView tv1;
        Button btnCustomLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            btn1 = (Button)FindViewById(Resource.Id.btn1);
            btn2 = (Button)FindViewById(Resource.Id.btn2);
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            var intent2 = new Intent(this, typeof(Activity2));
            StartActivity(intent2);
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            CreateLoginDialog();
            btnCustomLogin.Click += BtnCustomLogin_Click;
        }

        private void BtnCustomLogin_Click(object sender, EventArgs e)
        {
            d.Dismiss();
            var intent1 = new Intent(this, typeof(Activity1));
            StartActivity(intent1);
        }

        public void CreateLoginDialog()
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.layout1);
            d.SetTitle("Connecting");
            d.SetCancelable(true);
            tv1 = (TextView)d.FindViewById(Resource.Id.tv1);
            etUserName = (EditText)d.FindViewById(Resource.Id.et1);
            btnCustomLogin = (Button)d.FindViewById(Resource.Id.btn);
            d.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}