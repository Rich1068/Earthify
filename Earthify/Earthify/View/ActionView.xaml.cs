using Earthify.ViewModel;
using Earthify.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Earthify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionView : ContentPage
    {
        ActionViewModel _viewModel;
        bool _isUpdate;
        int actionID;

        public ActionView()
        {
            InitializeComponent();
            _viewModel = new ActionViewModel();
            _isUpdate = false;

            PopulateCategoryPicker();
        }

        public ActionView(ActionModel obj) : this()
        {
            if (obj != null)
            {
                actionID = obj.Id;
                txtDescription.Text = obj.Description;
                txtImpactlvl.Text = obj.Impact_Level;
                txtImpactdesc.Text = obj.Impact_Description;
                txtFrequency.Text = obj.Frequency;
                _isUpdate = true;

                // Set the selected category
                txtCategory.SelectedItem = obj.Category;
            }
        }

        private void PopulateCategoryPicker()
        {
            // Populate the picker with categories
            txtCategory.ItemsSource = new List<string>
            {
                "Low",
                "Medium",
                "High"
                // Add more categories here if needed
            };
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            ActionModel obj = new ActionModel
            {
                Description = txtDescription.Text,
                Category = (string)txtCategory.SelectedItem,
                Impact_Level = txtImpactlvl.Text,
                Impact_Description = txtImpactdesc.Text,
                Frequency = txtFrequency.Text
            };

            if (_isUpdate)
            {
                obj.Id = actionID;
                await _viewModel.UpdateAction(obj);
            }
            else
            {
                _viewModel.InsertAction(obj);
            }

            await this.Navigation.PopAsync();
        }
    }
}
