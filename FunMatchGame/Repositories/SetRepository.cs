using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using FunMatchGame.Models;
using Newtonsoft.Json;

namespace FunMatchGame.Repositories
{
	public class SetRepository : ISetRepository
	{
		private readonly IMappingEngine _mappingEngine;

		public SetRepository(IMappingEngine mappingEngine)
		{
			_mappingEngine = mappingEngine;
		}

		public Task<IList<Card>> GetCardsBySetIdAsync(Sets setId)
		{
			switch (setId)
			{
				case Sets.AbcStories:
					return GetAbcLocalStories();
				case Sets.AustralianWarMemorial:
					return GetAustralianWarMemorial();
			}

			return Task.FromResult<IList<Card>>(new List<Card>());
		}

		private async Task<IList<Card>> GetAustralianWarMemorial()
		{
			var apiUrl = "https://www.awm.gov.au/direct/data.php?key=ww1hack2015&q=type:%22Photograph%22&count=50";
			var r = new Random();
			apiUrl += "&start=" + r.Next(0, 2000);

			var client = new HttpClient();
			var result = await client.GetAsync(apiUrl);
			result.EnsureSuccessStatusCode();
			var data = await result.Content.ReadAsAsync<AustralianWarMemorialRootDataModel>();

			return (from d in data.results
					let url = new UriBuilder("https", d.url.Remove(0, 4))
					let imageUrl = "https://static.awm.gov.au/images/collection/items/ACCNUM_SCREEN/" + d.accession_number + ".JPG"
					select new Card(Guid.NewGuid(), d.title, imageUrl, url.ToString(), d.description)).ToList();
		}

		private string GetDataFile(string dataFileName)
		{
			return Path.Combine(HttpRuntime.AppDomainAppPath, "Data", dataFileName);
		}

		private Task<IList<Card>> GetAbcLocalStories()
		{
			using (var r = new StreamReader(GetDataFile("Localphotostories2009-2014-JSON.json")))
			{
				var json = r.ReadToEnd();
				dynamic items = JsonConvert.DeserializeObject(json);
				var cards = new List<Card>();
				foreach (var item in items)
				{
					if (string.IsNullOrWhiteSpace(item["Primary image"].ToString()))
						continue;
					cards.Add(new Card(Guid.NewGuid(), item["Title"].ToString(), item["Primary image"].ToString(), item["URL"].ToString(), item["Primary image caption"].ToString()));
				}
				return Task.FromResult<IList<Card>>(cards);
			}
		}
	}
}