using CommunityToolkit.Mvvm.ComponentModel;

namespace Pokedex.Maui.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private bool _isBusy;
    }
}
