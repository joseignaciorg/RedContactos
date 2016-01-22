﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedContactos.Module;
using Xamarin.Forms;

namespace RedContactos
{
    public class App : Application
    {
        public App()
        {
            var start = new StartUp(this);
            start.Run();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
