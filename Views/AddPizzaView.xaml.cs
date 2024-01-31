using MauiPizzeriaApp.ViewModels;

namespace MauiPizzeriaApp.Views;

public partial class AddPizzaView : ContentPage
{
	public AddPizzaView()
	{
		InitializeComponent();
		BindingContext = new AddPizzaViewModel();
	}
}