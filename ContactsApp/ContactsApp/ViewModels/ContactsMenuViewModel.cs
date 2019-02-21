using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ContactsApp.Services.Contracts;
using ContactsApp.Models;

namespace ContactsApp.ViewModels
{
    public class ContactsMenuViewModel : BaseViewModel
    {
        private readonly IContactService _contactService;
        public IEnumerable<ContactList> ContactGroups { get; set; }
        public IEnumerable<ContactList> Contacts { get; set; }

        public ContactsMenuViewModel(IContactService contactService)
        {
            Title = "Contacts";
            _contactService = contactService;
        }

        public override async Task OnAppearing()
        {
            IsBusy = true;
            ContactGroups = await _contactService.GetContactsGroups();
            //IList<Contact> contacts = await CrossContactService.Current.GetContactListAsync();     
            IsBusy = false;
        }
    }
}
