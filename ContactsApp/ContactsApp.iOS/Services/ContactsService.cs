using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts;
using ContactsApp.iOS.Services;
using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactsService))]
namespace ContactsApp.iOS.Services
{
    public class ContactsService : IContactsService
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<Contact>> GetContacts()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var response = new List<Contact>();

            var keysToFetch = new[] {
                CNContactKey.PhoneNumbers,
                CNContactKey.GivenName,
                CNContactKey.EmailAddresses
            };

            var containerId = new CNContactStore().DefaultContainerIdentifier;

            using (var predicate = CNContact.GetPredicateForContactsInContainer(containerId))
            {
                CNContact[] contactList;
                using (var store = new CNContactStore())
                {
                    contactList = store.GetUnifiedContacts(predicate, keysToFetch, out var error);
                }

                //Assign the contact details to our view model objects  
                response.AddRange(from item in contactList
                                  where item?.EmailAddresses != null
                                  select new Contact
                                  {
                                      Number = item.PhoneNumbers[0].ToString(),
                                      Name = item.GivenName,
                                      Email = item.EmailAddresses.Select(m => m.Value.ToString()).FirstOrDefault()
                                  });
            }

            return response;
        }
    }
}