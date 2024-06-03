using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthify
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.ShowActionPage())
            {
                BarBackgroundColor = Color.FromHex("#254336"),
                BackgroundColor = Color.FromHex("#DAD3BE")
            };
            MainPage = new NavigationPage(new View.Main());
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
