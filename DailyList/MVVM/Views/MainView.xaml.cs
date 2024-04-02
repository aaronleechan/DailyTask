using DailyList.MVVM.ViewModels;
namespace MauiApp1;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}