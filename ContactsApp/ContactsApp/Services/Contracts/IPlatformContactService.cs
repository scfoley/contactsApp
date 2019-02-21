using ContactsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsApp.Services.Contracts
{
    public interface IPlatformContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
    }
}
