﻿using ContactsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApp.Services.Contracts
{
    public interface IContactService
    {
        IEnumerable<Contact> LoadedContacts { get; set; }
        Contact SelectedContact { get; set; }
        void SaveFavoriteContact(Contact contact);
        Contact LoadFavoriteContact();
        void ClearFavoriteContact();
        Task<IEnumerable<ContactList>> GetContactsGroups(bool forceReload = false);
        string GetHeading(Contact contact);
    }
}
