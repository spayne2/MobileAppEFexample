using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MobileAppEFexample
{
    public partial class PeoplePage : ContentPage, INotifyPropertyChanged
    {
        public PeoplePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            peopleCollectionView.SelectedItem = null;

            using (var runningContext = new RunningContext())
            {
                var thePeople = runningContext.People.ToList();

                peopleCollectionView.ItemsSource = thePeople;
            }
        }


        async void peopleCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Person person))
                return;

            var postsPage = new RunsPage(person.PersonID);
            await Navigation.PushAsync(postsPage);
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddPersonPage()));
        }

        async void DeleteAll_Clicked(object sender, EventArgs e)
        {
            using (var runningContext = new RunningContext())
            {
                runningContext.RemoveRange(runningContext.People);

                await runningContext.SaveChangesAsync();

                peopleCollectionView.ItemsSource = runningContext.People.ToList();
            }
        }
    }
}