using Newtonsoft.Json;
using PropertyChanged;
using System;

namespace ContactsApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Contact : ICloneable
    {
        public bool IsFavorite { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }

        public object Clone()
        {
            return JsonConvert.DeserializeObject<Contact>(JsonConvert.SerializeObject(this));
        }
    }
}