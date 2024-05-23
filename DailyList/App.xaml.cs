using MauiApp1;

namespace DailyList;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new MainView();
		//MainPage = new NewTaskView();
		MainPage = new NavigationPage(new MainView());
	}
}
