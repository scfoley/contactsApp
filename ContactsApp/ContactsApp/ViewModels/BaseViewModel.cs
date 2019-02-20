using PropertyChanged;
using System.Threading.Tasks;

namespace ContactsApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public virtual Task OnAppearing() { return Task.CompletedTask; }
        public virtual Task OnDisappearing() { return Task.CompletedTask; }
    }
}
