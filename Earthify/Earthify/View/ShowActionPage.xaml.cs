using Earthify.Model;
using Earthify.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowActionPage : ContentPage
    {
        ActionViewModel viewModel;
        public ShowActionPage()
        {
            InitializeComponent();
            viewModel = new ActionViewModel();

        }
        private void showActionPage()
        {
            var res = viewModel.GetAllAction().Result;
            lstData.ItemsSource = res;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            showActionPage();
        }
        private void btnAddRecord(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ActionView());
        }
        private async void lsdata_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ActionModel obj = (ActionModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "View", "Update", "Delete");

                switch (res)
                {
                    case "View":
                        await this.Navigation.PushAsync(new ViewAction(obj));
                        break;
                    case "Update":
                        await this.Navigation.PushAsync(new ActionView(obj));
                        break;

                    case "Delete":
                        viewModel.DeleteAction(obj);
                        showActionPage();
                        break;
                }

                lstData.SelectedItem = null;
            }
        }


    }

}