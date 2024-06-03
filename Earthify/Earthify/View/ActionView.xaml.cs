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
                txtCategory.Text = obj.Category;
                txtImpactlvl.Text = obj.Impact_Level;
                txtImpactdesc.Text = obj.Impact_Description;
                txtFrequency.Text = obj.Frequency;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            ActionModel obj = new ActionModel();
            obj.Description = txtDescription.Text;
            obj.Category = txtCategory.Text;
            obj.Impact_Level = txtImpactlvl.Text;
            obj.Impact_Description = txtImpactdesc.Text;
            obj.Frequency = txtFrequency.Text;

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