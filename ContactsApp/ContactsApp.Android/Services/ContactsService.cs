using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ContactsApp.Droid.Services;
using ContactsApp.Models;
using ContactsApp.Services.Contracts;
using Plugin.ContactService;
using Xamarin.Forms;


[assembly: Dependency(typeof(ContactsService))]
namespace ContactsApp.Droid.Services
{
    public class ContactsService : IContactsService
    {
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var resultingContacts = new List<Contact>();
            var contacts = await CrossContactService.Current.GetContactListAsync();

            foreach(var contact in contacts)
            {
                resultingContacts.Add(new Contact
                {
                    Name = contact.Name,
                    Email = contact.Email,
                    Number = contact.Number
                });
            }

            return resultingContacts;
        }
    }
}