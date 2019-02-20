using Plugin.ContactService;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace ContactsApp.ViewModels
{
    public class ContactsMenuViewModel : BaseViewModel
    {
        public ContactsMenuViewModel()
        {
            Title = "Contacts";
        }

        public override async Task OnAppearing()
        {
            IsBusy = true;
            IList<Contact> contacts = await CrossContactService.Current.GetContactListAsync();     
            IsBusy = false;
        }
    }
}
