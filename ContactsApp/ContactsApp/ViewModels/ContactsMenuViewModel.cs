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
        private readonly IContactsService _contactService;
        public IEnumerable<Contact> Contacts { get; set; }

        public ContactsMenuViewModel(IContactsService contactService)
        {
            Title = "Contacts";
            _contactService = contactService;
        }

        public override async Task OnAppearing()
        {
            IsBusy = true;
            Contacts = await _contactService.GetContacts();
            //IList<Contact> contacts = await CrossContactService.Current.GetContactListAsync();     
            IsBusy = false;
        }
    }
}
