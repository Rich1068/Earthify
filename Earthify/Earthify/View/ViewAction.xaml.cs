using Earthify.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAction : ContentPage
    {
        public ViewAction(ActionModel action)
        {
            InitializeComponent();
            DisplayAction(action);
        }

        private void DisplayAction(ActionModel action)
        {
            lblActionCode.Text = action.ActionCode;
            lblDescription.Text = action.Description;
            lblCategory.Text = action.Category;
            lblImpactlvl.Text = action.Impact_Level;
            lblImpactdesc.Text = action.Impact_Description;
            lblFrequency.Text = action.Frequency;

            SetBackgroundColor(action.Category);
        }

        private void SetBackgroundColor(string category)
        {
            Color backgroundColor;

            switch (category.ToLower())
            {
                case "trees":
                    backgroundColor = Color.LightGreen;
                    break;
                case "ocean":
                    backgroundColor = Color.LightBlue;
                    break;
                case "waste":
                    backgroundColor = Color.Beige;
                    break;
                default:
                    backgroundColor = Color.White;
                    break;
            }

            stackLayout.BackgroundColor = backgroundColor;
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
