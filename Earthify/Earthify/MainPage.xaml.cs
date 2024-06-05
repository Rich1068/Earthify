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
                new ImageModel(){Title="Image 1",Url="https://i.ibb.co/PFtB8Mh/1.png"},
                new ImageModel(){Title="Image 2",Url="https://i.ibb.co/FXTbT34/2.png"},
                new ImageModel(){Title="Image 3",Url="https://i.ibb.co/ngSt0Z8/3.png"}
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
