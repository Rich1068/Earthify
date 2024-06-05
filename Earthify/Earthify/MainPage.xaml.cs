using Earthify.Model;
using Earthify.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Earthify
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<ImageModel> images = new List<ImageModel>()
            {
                new ImageModel(){Title="Image 1",Url="drawable/page1.png"},
                new ImageModel(){Title="Image 2",Url="drawable/page2.png"},
                new ImageModel(){Title="Image 3",Url="drawable/page3.png"}
            };

            Carousel.ItemsSource = images;

            Device.StartTimer(TimeSpan.FromSeconds(4), (Func<bool>)(() =>
            {
                Carousel.Position = (Carousel.Position + 1) % images.Count;
                return true;
            }));
        }

        private async void btnViewRecord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowActionPage());
        }
    }
}
