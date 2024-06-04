﻿using Earthify.ViewModel;
using Earthify.Model;
using System;
using System.Collections.Generic;
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

            PopulateCategoryPicker();
        }

        public ActionView(ActionModel obj) : this()
        {
            if (obj != null)
            {
                actionID = obj.Id;
                txtDescription.Text = obj.Description;
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
                txtCategory.SelectedItem = categories.FirstOrDefault(c => c == obj.Category);
            }
            if (txtCategory.ItemsSource is IList<string> impactlvl)
            {
                txtImpactlvl.SelectedItem = impactlvl.FirstOrDefault(c => c == obj.Impact_Level);
            }
        }
        
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            ActionModel obj = new ActionModel();
            obj.Description = txtDescription.Text;
            obj.Category = (string)txtCategory.SelectedItem;
            obj.Impact_Level = (string)txtImpactlvl.SelectedItem;
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
