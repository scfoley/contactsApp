using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IPlatformContactService _platformContactService;

        public ContactService(IPlatformContactService platformContactService)
        {
            _platformContactService = platformContactService;
        }

        public List<Contact> LoadedContacts { get; set; }

        public Task<List<ContactList>> GetContactsGroups()
        {
            throw new NotImplementedException();
        }

        public Contact LoadFavoriteContact()
        {
            throw new NotImplementedException();
        }

        public void SaveFavoriteContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
