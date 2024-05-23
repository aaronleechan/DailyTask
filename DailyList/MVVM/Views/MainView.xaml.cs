using DailyList;
using DailyList.MVVM.ViewModels;
namespace MauiApp1;

public partial class MainView : ContentPage
{
	private MainViewModel mainViewModel = new MainViewModel();
	public MainView()
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

	private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		mainViewModel.UpdateData();
	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		var taskView = new NewTaskView
		{
			BindingContext = new NewTaskViewModel
			{
				Tasks = mainViewModel.Tasks,
				Categories = mainViewModel.Categories,
			}
		};

		Navigation.PushAsync(taskView);
	}
}