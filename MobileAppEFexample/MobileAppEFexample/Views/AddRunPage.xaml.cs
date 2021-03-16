using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Xamarin.Forms;

namespace MobileAppEFexample
{
    public partial class AddRunPage : ContentPage
    {
        int PersonID;

        public AddRunPage(int personID)
        {
            InitializeComponent();

            PersonID = personID;
        }

        protected async void Save_Clicked(object sender, EventArgs e)
        {
            var newRun = new Run
            {
                PersonID = PersonID,
                DistanceInKM = float.Parse(DistanceInKMCell.Text, CultureInfo.InvariantCulture),
                TimeInMins = Int32.Parse(TimeInMinsCell.Text),
                TimeInSeconds = Int32.Parse(TimeInSecondsCell.Text),
                Terrain = TerrainCell.Text,
            };

            newRun.setPace();

            try
            {
                using (var runningContext = new RunningContext())
                {
                    await runningContext.Runs.AddAsync(newRun);

                    await runningContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            await Navigation.PopModalAsync();
        }

        protected async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}