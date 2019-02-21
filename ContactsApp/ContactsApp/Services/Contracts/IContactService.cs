using ContactsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApp.Services.Contracts
{
    public interface IContactService
    {
        List<Contact> LoadedContacts { get; set; }
        void SaveFavoriteContact(Contact contact);
        Contact LoadFavoriteContact();
        Task<List<ContactList>> GetContactsGroups();
    }
}
