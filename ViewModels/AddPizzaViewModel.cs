using CommunityToolkit.Mvvm.Input;
using MauiPizzeriaApp.Data;
using MauiPizzeriaApp.Models;
using MauiPizzeriaApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiPizzeriaApp.ViewModels
{
    public partial class AddPizzaViewModel : MainViewModel
    {
        public AddPizzaViewModel()
        {
        }

		#region New values
        public string NewNo { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public decimal NewPrice { get; set; }
        #endregion


        #region Methods
        [RelayCommand]
        public async Task AddPizza()
        {
			if (NewNo.Length <= 3 && Regex.IsMatch(NewNo, @"^\d+$") && NewName.Length <= 30 && NewDescription.Length <= 120)
            {
				var newPizza = new Pizza
				{
					No = NewNo,
					Name = NewName,
					Description = NewDescription,
					Price = NewPrice
				};
				var inserted = await _database.AddPizza(newPizza);
				if (inserted != 0)
				{
					Pizzas.Add(newPizza);
					NewNo = string.Empty;
					NewName = string.Empty;
					NewDescription = string.Empty;
					NewPrice = 0;
				}
				await Application.Current.MainPage.Navigation.PopAsync();
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid values", "OK");
			}

		}

		[RelayCommand]
		public async Task Cancel()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
		#endregion
	}
}
