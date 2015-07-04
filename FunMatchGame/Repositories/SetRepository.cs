using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FunMatchGame.Models;
using Newtonsoft.Json;

namespace FunMatchGame.Repositories
{
	public class SetRepository : ISetRepository
	{
		public Task<IEnumerable<Card>> GetCardsBySetIdAsync(Sets setId)
		{
			switch (setId)
			{
				case Sets.AbcStories:
					return GetCardsAsync(GetDataFile("Localphotostories2009-2014-JSON.json"));
			}

			return Task.FromResult(new List<Card>().AsEnumerable());
		}

		private string GetDataFile(string dataFileName)
		{
			return Path.Combine(HttpRuntime.AppDomainAppPath, "Data", dataFileName);
		}

		private Task<IEnumerable<Card>> GetCardsAsync(string jsonFileName)
		{
			using (var r = new StreamReader(jsonFileName))
			{
				var json = r.ReadToEnd();
				dynamic items = JsonConvert.DeserializeObject(json);
				var cards = new List<Card>();
				foreach (var item in items)
					cards.Add(new Card(Guid.NewGuid(), item["Title"].ToString(), item["Primary image"].ToString(), item["URL"].ToString(), item["Primary image caption"].ToString()));

				return Task.FromResult(cards.AsEnumerable());
			}
		}
	}
}