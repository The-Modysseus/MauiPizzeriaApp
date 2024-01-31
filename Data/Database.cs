using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiPizzeriaApp.Models;

namespace MauiPizzeriaApp.Data
{
	public class Database
	{
		private static readonly Lazy<Database> instance = new Lazy<Database>(() => new Database());
		public static Database Instance => instance.Value;
		private readonly SQLiteAsyncConnection _connection;

		public Database()
		{
			var dataDir = FileSystem.AppDataDirectory;
			var databasePath = Path.Combine(dataDir, "MauiPizzeriaApp.db");

			string _dbEncryptionKey = SecureStorage.GetAsync("dbKey").Result;

			if (string.IsNullOrEmpty(_dbEncryptionKey))
			{
				Guid g = new Guid();
				_dbEncryptionKey = g.ToString();
				SecureStorage.SetAsync("dbKey", _dbEncryptionKey);
			}

			var dbOptions = new SQLiteConnectionString(databasePath, true, key: _dbEncryptionKey);

			_connection = new SQLiteAsyncConnection(dbOptions);

			_ = Initialise();
		}

		public static async Task<Database> CreateAsync()
		{
			var database = new Database();
			await database.Initialise();
			return database;
		}

		private async Task Initialise()
		{
			await _connection.CreateTableAsync<Pizza>();
			await _connection.CreateTableAsync<Order>();
			await _connection.CreateTableAsync<OrderLine>();
		}

		public async Task<List<Pizza>> GetPizzas()
		{
			return await _connection.Table<Pizza>().ToListAsync();
		}

		public async Task<List<Order>> GetOrders()
		{
			return await _connection.Table<Order>().ToListAsync();
		}

		public async Task<List<OrderLine>> GetOrderLines()
		{
			return await _connection.Table<OrderLine>().ToListAsync();
		}

		public async Task<Pizza> GetPizza(int id)
		{
			var query = _connection.Table<Pizza>().Where(t => t.Id == id);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<Order> GetOrder(int id)
		{
			var query = _connection.Table<Order>().Where(t => t.Id == id);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<OrderLine> GetOrderLine(int id)
		{
			var query = _connection.Table<OrderLine>().Where(t => t.Id == id);

			return await query.FirstOrDefaultAsync();
		}

		public async Task<int> AddPizza(Pizza item)
		{
			return await _connection.InsertAsync(item);
		}

		public async Task<int> AddOrder(Order item)
		{
			return await _connection.InsertAsync(item);
		}

		public async Task<int> AddOrderLine(OrderLine item)
		{
			return await _connection.InsertAsync(item);
		}

		public async Task<int> DeletePizza(Pizza item)
		{
			return await _connection.DeleteAsync(item);
		}

		public async Task<int> DeleteOrder(Order item)
		{
			return await _connection.DeleteAsync(item);
		}

		public async Task<int> DeleteOrderLine(OrderLine item)
		{
			return await _connection.DeleteAsync(item);
		}

		public async Task<int> UpdateOrder(Order item)
		{
			return await _connection.UpdateAsync(item);
		}

		public async Task<int> UpdateOrderLine(OrderLine item)
		{
			return await _connection.UpdateAsync(item);
		}
	}
}
