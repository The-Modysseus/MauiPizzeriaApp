using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiPizzeriaApp.Models
{
	public class Order : INotifyPropertyChanged
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Salesman { get; set; } = string.Empty;
		public DateTime DateTime { get; set; } = DateTime.Now;
		public decimal Total { get; set; } = decimal.Zero;

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
