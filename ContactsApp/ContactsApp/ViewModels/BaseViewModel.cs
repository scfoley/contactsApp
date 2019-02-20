using PropertyChanged;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public string Title { get; set; }
        public bool IsBusy { get; set; }
        public virtual Task OnAppearing() { return Task.CompletedTask; }
        public virtual Task OnDisappearing() { return Task.CompletedTask; }
    }
}
