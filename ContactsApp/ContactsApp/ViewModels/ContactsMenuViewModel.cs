using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ContactsApp.Services.Contracts;
using ContactsApp.Models;
using System.Collections.ObjectModel;

namespace ContactsApp.ViewModels
{
    public class ContactsMenuViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        public ObservableCollection<ContactList> ObservableContactLists { get; set; }
        public IEnumerable<ContactList> Contacts { get; set; }

        public ContactsMenuViewModel(IContactService contactService)
        {
            Title = "Contacts";
            _contactService = contactService;
        }

        public override async Task OnAppearing()
        {
            IsBusy = true;
            var tempContactLists = await _contactService.GetContactsGroups();
            ObservableContactLists = new ObservableCollection<ContactList>(tempContactLists);
            IsBusy = false;
        }
    }
}
