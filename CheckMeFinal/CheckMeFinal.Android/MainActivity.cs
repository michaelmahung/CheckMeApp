using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using Android.Support.V4.App;
using Android;
using System.IO;
using Android.Content;

namespace CheckMeFinal.Droid
{
    [Activity(Label = "CheckMeFinal", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            await CrossMedia.Current.Initialize();

            string fileName = "users_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);

            //string defaultPath = String.Format(Path.Combine((string)Android.OS.Environment.ExternalStorageDirectory, "CheckMe"));

            string defaultPath = String.Format(fileLocation);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(full_path, defaultPath));

            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera, Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 1);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}