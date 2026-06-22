using ChronicleOnline.ViewModels;
namespace ChronicleOnline.Views;


public partial class LiveStatusPage : ContentPage
{
	public LiveStatusPage()
	{
		InitializeComponent();
        BindingContext = new LiveStatusViewModel();
    }
}