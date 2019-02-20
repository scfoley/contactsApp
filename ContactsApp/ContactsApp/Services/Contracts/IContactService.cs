using ContactsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApp.Services.Contracts
{
    public interface IContactsService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
