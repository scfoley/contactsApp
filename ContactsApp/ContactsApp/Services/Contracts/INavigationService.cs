using ContactsApp.Views;

namespace ContactsApp.Services.Contracts
{
    public interface INavigationService
    {
        void OpenPage<TView>() where TView : BaseView;
        void DisplayAlert(string title, string message, string cancel);
    }
}
