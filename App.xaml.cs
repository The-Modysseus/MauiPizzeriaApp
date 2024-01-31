using MauiPizzeriaApp.Data;
using MauiPizzeriaApp.Views;

namespace MauiPizzeriaApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainView());
		}

		protected override async void OnStart()
		{
			base.OnStart();
			await Database.CreateAsync();
		}
	}
}
