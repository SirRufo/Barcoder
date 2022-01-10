using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Barcoder.WpfApp.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        [Reactive] public string Barcode { get; set; } = string.Empty;
    }
}
