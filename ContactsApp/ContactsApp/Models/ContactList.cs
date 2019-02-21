using System.Collections.Generic;

namespace ContactsApp.Models
{
    public class ContactList : List<Contact>
    {
        public string Heading { get; set; }
    }
}
