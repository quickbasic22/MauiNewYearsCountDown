using MauiNewYearsCountDown.Controls;

namespace MauiNewYearsCountDown;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}
}
