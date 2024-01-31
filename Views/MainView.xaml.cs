using MauiPizzeriaApp.ViewModels;

namespace MauiPizzeriaApp
{
	public partial class MainView : ContentPage
	{
		public MainView()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
		}
	}
}
