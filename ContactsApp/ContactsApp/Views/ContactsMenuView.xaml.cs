using ContactsApp.ViewModels;
using Xamarin.Forms;

namespace ContactsApp.Views
{
    public partial class ContactsMenuView : ContentPage
    {
        public ContactsMenuView(ContactsMenuViewModel contactsMenuViewModel)
        {
            InitializeComponent();
            BindingContext = contactsMenuViewModel;
        }
    }
}
