using ContactsApp.ViewModels;
using Xamarin.Forms;

namespace ContactsApp.Views
{
    public partial class ContactsMenuView : BaseView
    {
        public ContactsMenuView(ContactsMenuViewModel contactsMenuViewModel)
        {
            InitializeComponent();
            BindingContext = contactsMenuViewModel;
            Title = contactsMenuViewModel.Title;
        }
    }
}
