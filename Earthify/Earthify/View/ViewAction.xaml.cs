using Earthify.Model;
using Earthify.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Earthify.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAction : ContentPage
    {
        private double progressIncrement;
        private string actionCode;
        private DatabaseContext _dbContext;
        int actionId;

        public ViewAction(ActionModel action)
        {
            InitializeComponent();
            _dbContext = new DatabaseContext();
            actionId = action.Id;
            DisplayAction(action);
            LoadProgress(action);
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

            progressIncrement = ConvertFrequencyToProgressIncrement(action.Frequency);
        }

        private double ConvertFrequencyToProgressIncrement(string frequency)
        {
            switch (frequency.ToLower())
            {
                case "always":
                    return 0.1;
                case "often":
                    return 0.075;
                case "sometimes":
                    return 0.05;
                case "rarely":
                    return 0.025;
                default:
                    return 0.1; 
            }
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

        private async void OnUpdateProgressClicked(object sender, EventArgs e)
        {

            if (progressBar.Progress + progressIncrement <= 1)
            {
                await progressBar.ProgressTo(progressBar.Progress + progressIncrement, 250, Easing.Linear);
                SaveProgress(progressBar.Progress + progressIncrement);
            }
            else
            {
                progressBar.Progress = 1.0;
                SaveProgress(1.0);
            }

            // Disable the button if progress is full
            if (progressBar.Progress >= 1.0)
            {
                bool deleteAction = await DisplayAlert("Congratulations", "Congratulations for Completing the Task. Do you want to delete the task and do another one?", "Yes", "No");
                if (deleteAction == true)
                {
                    contributeButton.IsEnabled = false;
                    await DisplayAlert("Success", "Action deleted successfully.", "OK");
                    int result = DeleteAction(actionId); 
                    await Navigation.PopAsync();

                } else
                {

                }

            }
        }

        private void SaveProgress(double progress)
        {
            var action = _dbContext.Actionss.FirstOrDefault(a => a.Id == actionId);
            if (action != null)
            {
                action.ProgressValue = progress;
                _dbContext.Actionss.Update(action);
                _dbContext.SaveChanges();
            }
        }

        private void LoadProgress(ActionModel action)
        {
            var savedAction = _dbContext.Actionss.FirstOrDefault(a => a.Id == actionId);
            if (savedAction != null)
            {
                progressBar.Progress = savedAction.ProgressValue;
            }
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private int DeleteAction(int actionId)
        {
            using (var _dbContext = new DatabaseContext())
            {
                var action = _dbContext.Actionss.FirstOrDefault(a => a.Id == actionId);
                if (action != null)
                {
                    _dbContext.Actionss.Remove(action);
                    int affectedRows = _dbContext.SaveChanges();
                    return affectedRows;
                }
                return 0;
            }
        }
    }
}
