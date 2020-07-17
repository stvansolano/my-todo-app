using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared;
using Xamarin.Essentials;
using XamarinExplorer.Services;

namespace XamarinExplorer
{
	public class ToDoItemsRepository : Repository<Item>
	{
		private List<Item> _items;

		public override async Task<IEnumerable<Item>> GetAsync(bool forceRefresh = false)
		{
			if (forceRefresh && Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				var json = await GetClient().GetStringAsync("HttpGetTrigger");
				_items = JsonConvert.DeserializeObject<List<Item>>(json);
			}

			return _items.OrderByDescending(item => item.DateCreated);
		}

		public async Task PostAsync(Item model)
		{
			_items.Add(model);

			var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

			await GetClient().PostAsync("HttpPostTrigger", content);
		}

		public async override Task<bool> UpdateAsync(object id, Item item)
		{
			if (item == null || id == null || Connectivity.NetworkAccess != NetworkAccess.Internet)
				return false;

			var serializedItem = JsonConvert.SerializeObject(item);
			var buffer = Encoding.UTF8.GetBytes(serializedItem);
			var byteContent = new ByteArrayContent(buffer);

			var response = await GetClient().PutAsync(new Uri($"/api/todo/{id}"), byteContent);

			return response.IsSuccessStatusCode;
		}
	}
}