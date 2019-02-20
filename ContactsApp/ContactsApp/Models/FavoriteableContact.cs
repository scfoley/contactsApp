using Plugin.ContactService.Shared;

namespace ContactsApp.Models
{
    public class FavoriteableContact : Contact
    {
        public bool IsFavorite { get; set; }
    }
}
