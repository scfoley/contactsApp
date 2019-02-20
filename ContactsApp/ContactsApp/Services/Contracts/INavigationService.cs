using ContactsApp.Views;

namespace ContactsApp.Services.Contracts
{
    public interface INavigationService
    {
        void OpenPage<TView>() where TView : BaseView;
    }
}
