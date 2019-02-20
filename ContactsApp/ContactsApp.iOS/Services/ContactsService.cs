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
            var resultingContacts = new List<Contact>();

            var keysToFetch = new[] {
                #pragma warning disable XI0002 // Notifies you from using newer Apple APIs when targeting an older OS version
                CNContactKey.PhoneNumbers,
                CNContactKey.GivenName,
                CNContactKey.EmailAddresses,
                CNContactKey.FamilyName
                #pragma warning restore XI0002 // Notifies you from using newer Apple APIs when targeting an older OS version
            };

            var containerId = new CNContactStore().DefaultContainerIdentifier;

            using (var predicate = CNContact.GetPredicateForContactsInContainer(containerId))
            {
                CNContact[] contactList;
                using (var store = new CNContactStore())
                {
                    contactList = store.GetUnifiedContacts(predicate, keysToFetch, out var error);
                }

                resultingContacts.AddRange(from item in contactList
                                  where item?.EmailAddresses != null
                                  select new Contact
                                  {
                                      Number = item.PhoneNumbers.Any() ? item.PhoneNumbers[0]?.Value?.ValueForKey(new Foundation.NSString("stringValue"))?.ToString() : null,
                                      Name = item.GivenName + " " + item.FamilyName,
                                      FirstName = item.GivenName,
                                      LastName = item.FamilyName,
                                      Email = item.EmailAddresses.Select(m => m.Value.ToString()).FirstOrDefault()
                                  });
            }

            resultingContacts.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));

            return resultingContacts;
        }
    }
}