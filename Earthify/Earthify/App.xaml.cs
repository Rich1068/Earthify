using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthify
{
    public partial class App : Application
    {
        public static string ImageFolderPath { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Main())
            {
                BarBackgroundColor = Color.FromHex("#254336"),
                BackgroundColor = Color.FromHex("#DAD3BE")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
