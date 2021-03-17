using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppEFexample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPersonPage : ContentPage
    {
        public AddPersonPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
           var person = new Person { Name = Name.Text, Age = Int32.Parse(Age.Text), EmailAddress = EmailAddress.Text, Gender = Gender.Text};

            using (var runningContext = new RunningContext())
            {
                runningContext.Add(person);

                await runningContext.SaveChangesAsync();
            }

            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}