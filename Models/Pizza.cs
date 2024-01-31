using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiPizzeriaApp.Models
{
	public class Pizza : INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string No { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public void RaisePropertyChanged(params string[] properties)
		{
			foreach (var propertyName in properties)
			{
				PropertyChanged?.Invoke(this, new
				PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
