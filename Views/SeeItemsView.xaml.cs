using MauiPizzeriaApp.ViewModels;

namespace MauiPizzeriaApp.Views;

public partial class SeeItemsView : ContentPage
{
	public SeeItemsView()
	{
		InitializeComponent();
		BindingContext = new SeeItemsViewModel();
	}

	private SeeItemsViewModel viewModel => BindingContext as SeeItemsViewModel;
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await viewModel.ReloadData();
	}
}