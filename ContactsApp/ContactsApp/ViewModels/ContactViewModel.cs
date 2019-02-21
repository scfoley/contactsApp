using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        // Services
        private IContactService _contactService;

        // Commands
        public ICommand ToggleFavoriteCommand { get; set; }

        // Properties
        public Contact SelectedContact { get; set; }

        public string ContactHeader { get; set; }

        public ContactViewModel(IContactService contactService)
        {
            _contactService = contactService;

            ToggleFavoriteCommand = new Command(ToggleFavorite);

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

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
        }
    }
}
