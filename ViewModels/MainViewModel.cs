using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiPizzeriaApp.Data;
using MauiPizzeriaApp.Views;
using MauiPizzeriaApp.Models;

namespace MauiPizzeriaApp.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		protected readonly Database _database;

		public MainViewModel()
		{
			_database = Database.Instance;
		}

		public ObservableCollection<Pizza> Pizzas { get; set; } = new();


		#region Methods
		[RelayCommand]
		private async Task ShowAddPizzaPage()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new AddPizzaView());
		}

		[RelayCommand]
		private async Task ShowSeeItemsPage()
		{
			await Application.Current.MainPage.Navigation.PushAsync(new SeeItemsView());
		}
		#endregion
	}
}
