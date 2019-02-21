using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public ContactViewModel(IContactService contactService)
        {
            _contactService = contactService;
            SelectedContact = _contactService.SelectedContact;
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
        }
    }
}
