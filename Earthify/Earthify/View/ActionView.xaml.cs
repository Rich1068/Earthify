using Earthify.ViewModel;
using Earthify.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Xml.Linq;
using System.IO;
using Xamarin.Essentials;

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
        }
        public ActionView(ActionModel obj)
        {
            InitializeComponent();
            _viewModel = new ActionViewModel();
            if (obj != null)
            {
                actionID = obj.Id;
                txtDescription.Text = obj.Description;
                txtImpactdesc.Text = obj.Impact_Description;
                _isUpdate = true;

                if (txtCategory.ItemsSource is IList<string> categories && categories.Any())
                {
                    txtCategory.SelectedItem = categories.FirstOrDefault(c => c == obj.Category);
                }

                if (txtImpactlvl.ItemsSource is IList<string> impactlvl && impactlvl.Any())
                {
                    txtImpactlvl.SelectedItem = impactlvl.FirstOrDefault(c => c == obj.Impact_Level);
                }

                if (txtFrequency.ItemsSource is IList<string> frequency && frequency.Any())
                {
                    txtFrequency.SelectedItem = frequency.FirstOrDefault(c => c == obj.Frequency);
                }
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            ActionModel obj = new ActionModel();
            obj.Description = txtDescription.Text;
            obj.Category = (string)txtCategory.SelectedItem;
            obj.Impact_Level = (string)txtImpactlvl.SelectedItem;
            obj.Impact_Description = txtImpactdesc.Text;
            obj.Frequency = (string)txtFrequency.SelectedItem;

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