﻿using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using XFDelivery.Interfaces;
using XFDelivery.Views;

using Xamarin.Forms.Xaml;
using XFDelivery.ViewModels;

namespace XFDelivery
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.Device.SetFlags(new[] { "Shapes_Experimental" });

            MainPage = new NavigationPage(new MainPage());

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
               DependencyService.Get<IStatusBarStyle>().ChangeTextColor();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios=1cd4c6d9-5ab8-4e5a-b0d6-51d22bad4897;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
