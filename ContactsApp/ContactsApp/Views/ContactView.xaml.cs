using ContactsApp.ViewModels;

namespace ContactsApp.Views
{
    public partial class ContactView : BaseView
	{
		public ContactView (ContactViewModel contactViewModel)
		{
			InitializeComponent ();
            BindingContext = contactViewModel;
            Title = contactViewModel.Title;
        }
	}
}