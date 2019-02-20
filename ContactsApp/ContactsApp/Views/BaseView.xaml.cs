using ContactsApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaseView : ContentPage
    {
		public BaseView()
		{
			InitializeComponent ();
		}

        private async void OnAppearing(object sender, EventArgs e)
            => await (BindingContext as BaseViewModel)?.OnAppearing();

        private async void OnDisappearing(object sender, EventArgs e)
            => await (BindingContext as BaseViewModel)?.OnDisappearing();
    }
}