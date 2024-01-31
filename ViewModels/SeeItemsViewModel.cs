using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiPizzeriaApp.ViewModels
{
    public partial class SeeItemsViewModel : MainViewModel
    {
        public SeeItemsViewModel() 
        {

        }

        public async Task ReloadData()
        {
            var items = await _database.GetPizzas();
            Pizzas.Clear();
            foreach (var item in items)
            {
                Pizzas.Add(item);
            }
        }

		#region Methods
		[RelayCommand]
		private async Task ShowMainPage()
		{
			await Application.Current.MainPage.Navigation.PopAsync();
		}
		#endregion
	}
}
