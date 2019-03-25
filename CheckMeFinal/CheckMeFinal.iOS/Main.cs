using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.Media;
using UIKit;

namespace CheckMeFinal.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            Application app = new Application();
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

            app.Initialize();
        }

        public async void Initialize()
        {
            await CrossMedia.Current.Initialize();
        }
    }
}
