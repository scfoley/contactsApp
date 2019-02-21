using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        // Services
        private IContactService _contactService;
        private INavigationService _navigationService;

        // Commands
        public ICommand ToggleFavoriteCommand { get; set; }
        public ICommand PhoneNumberTappedCommand { get; set; }

        // Properties
        public Contact SelectedContact { get; set; }

        public string ContactHeader { get; set; }

        public ContactViewModel(IContactService contactService, INavigationService navigationService)
        {
            _contactService = contactService;
            _navigationService = navigationService;

            ToggleFavoriteCommand = new Command(ToggleFavorite);
            PhoneNumberTappedCommand = new Command(PhoneNumberTapped);

            SelectedContact = _contactService.SelectedContact;

            ContactHeader = _contactService.GetHeading(SelectedContact);
        }

        private void ToggleFavorite()
        {
            SelectedContact.IsFavorite = !SelectedContact.IsFavorite;

            if (SelectedContact.IsFavorite)
                _contactService.SaveFavoriteContact(SelectedContact);
            else
                _contactService.ClearFavoriteContact();

            var favoriteContact = _contactService.LoadFavoriteContact();
        }

        private void PhoneNumberTapped()
        {
            try
            {
                PhoneDialer.Open(SelectedContact.Number);
            }
            catch
            {
                _navigationService.DisplayAlert("Error", "Unable to Dial Number...", "OK");
            }
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
        }
    }
}
