using PropertyChanged;
using System.Collections.Generic;

namespace ContactsApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class ContactList : List<Contact>
    {
        public string Heading { get; set; }
    }
}
