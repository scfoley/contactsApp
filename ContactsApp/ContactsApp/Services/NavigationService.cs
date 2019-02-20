using ContactsApp.Services.Contracts;
using ContactsApp.Views;
using Xamarin.Forms;

namespace ContactsApp.Services
{
    public class NavigationService : INavigationService
    {
        public IObjectService ObjectService { get; set; }
        public NavigationService(IObjectService objectService) => ObjectService = objectService;

        public void OpenPage<TView>() where TView : BaseView
        {
            var view = ObjectService.GetInstance<TView>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(view);
            });
        }
    }
}
