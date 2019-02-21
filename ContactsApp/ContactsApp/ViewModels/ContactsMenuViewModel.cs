using System.Threading.Tasks;
using ContactsApp.Services.Contracts;
using ContactsApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using ContactsApp.Views;

namespace ContactsApp.ViewModels
{
    public class ContactsMenuViewModel : BaseViewModel
    {
        // Services
        private IContactService _contactService;
        private INavigationService _navigationService;

        // Commands
        public ICommand ContactSelectedCommand { get; set; }

        // Properties
        public ObservableCollection<ContactList> ObservableContactLists { get; set; }

        public ContactsMenuViewModel(IContactService contactService, INavigationService navigationService)
        {
            Title = "Contacts";

            _contactService = contactService;
            _navigationService = navigationService;

            ContactSelectedCommand = new Command<ItemTappedEventArgs>(ContactSelected);
        }

        public override async Task OnAppearing()
        {
            IsBusy = true;
            await base.OnAppearing();
            var tempContactLists = await _contactService.GetContactsGroups();
            ObservableContactLists = new ObservableCollection<ContactList>(tempContactLists);
            IsBusy = false;
        }

        private void ContactSelected(ItemTappedEventArgs args)
        {
            var selectedContact = (Contact) args.Item;
            _contactService.SelectedContact = selectedContact;
            _navigationService.OpenPage<ContactView>();
        }
    }
}
