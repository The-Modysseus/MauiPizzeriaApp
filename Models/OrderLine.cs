using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiPizzeriaApp.Models
{
	public class OrderLine : INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[ForeignKey("Order:id")] // Reference to the Order table
		public int OrderId { get; set; }
		public int Count { get; set; }
		public string No { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public string Extra { get; set; } = string.Empty;
		public double SubTotal { get; set; }

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
