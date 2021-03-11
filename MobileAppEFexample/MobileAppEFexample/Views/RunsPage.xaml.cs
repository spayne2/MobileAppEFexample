using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace MobileAppEFexample
{
    public partial class RunsPage : ContentPage
    {
        int PersonId;

        public RunsPage(int personId)
        {
            InitializeComponent();

            PersonId = personId;
        }

        protected override void OnAppearing()
        {
            using (var runningContext = new RunningContext())
            {
                var runsList = runningContext.Runs
                    .Where(p => p.PersonID == PersonId)
                    .ToList();

                runsCollection.ItemsSource = runsList;
            }
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddRunPage(PersonId)));
        }
    }
}