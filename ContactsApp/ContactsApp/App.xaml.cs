using ContactsApp.Views;
using SimpleInjector;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ContactsApp
{
    public partial class App : Application
    {
        private static Container Container { get; set; }

        public App()
        {
            InitializeComponent();

            // SimpleInjector IOC
            Container = new Container();
            Container.Verify();

            MainPage = new ContactsMenuView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
