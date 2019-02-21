using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp.Services
{
    public class ContactService : IContactService
    {
        private readonly IPlatformContactService _platformContactService;

        public IEnumerable<Contact> LoadedContacts { get; set; }
        public Contact SelectedContact { get; set; }

        public ContactService(IPlatformContactService platformContactService)
        {
            _platformContactService = platformContactService;
        }

        public async Task<IEnumerable<ContactList>> GetContactsGroups(bool forceReload = false)
        {
            List<ContactList> result = new List<ContactList>();

            // Reload contact list if requested, otherwise reuse
            if (forceReload == true || LoadedContacts == null || !LoadedContacts.Any())
            {
                LoadedContacts = await _platformContactService.GetContacts();
            }

            foreach (var contact in LoadedContacts)
            {
                contact.IsFavorite = false;
            }

            // Get favorite contact
            var favoriteContact = LoadFavoriteContact();

            // Update favorite contact in list
            if(favoriteContact != null)
            {
                var matchingContact = LoadedContacts.FirstOrDefault(x => x.Number == favoriteContact.Number);

                if(matchingContact != null)
                {
                    matchingContact.IsFavorite = true;
                    favoriteContact = matchingContact;

                    var favoriteContactList = new ContactList
                    {
                        favoriteContact
                    };

                    favoriteContactList.Heading = "Favorite";
                    result.Add(favoriteContactList);
                }
            }

            var headers = LoadedContacts.Select(x => GetHeading(x));
            var uniqueHeaders = new HashSet<string>(headers).ToList();
            uniqueHeaders.Sort((x, y) => string.Compare(x, y));

            foreach (var uniqueHeader in uniqueHeaders)
            {
                var group = new ContactList
                {
                    Heading = uniqueHeader
                };

                group.AddRange(LoadedContacts.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name[0].ToString() == uniqueHeader));

                result.Add(group);
            }

            return result;
        }

        public string GetHeading(Contact contact)
        {
            if(!string.IsNullOrEmpty(contact.Name))
            {
                return contact.Name[0].ToString();
            }
            else
            {
                return "...";
            }
        }

        public Contact LoadFavoriteContact()
        {
            string contactKey = typeof(Contact).FullName;

            if (!Application.Current.Properties.ContainsKey(contactKey))
                return null;

            string json = Application.Current.Properties[contactKey] as string;
            var favoriteContact = JsonConvert.DeserializeObject<Contact>(json);
            return favoriteContact;
        }

        public void SaveFavoriteContact(Contact contact)
        {
            LoadedContacts.Select(x => x.IsFavorite = false);

            string json = JsonConvert.SerializeObject(contact);
            Application.Current.Properties[contact.GetType().FullName] = json;
            Application.Current.SavePropertiesAsync();
        }

        public void ClearFavoriteContact()
        {
            LoadedContacts.Select(x => x.IsFavorite = false);

            Application.Current.Properties.Remove(typeof(Contact).FullName);
            Application.Current.SavePropertiesAsync();
        }
    }
}
