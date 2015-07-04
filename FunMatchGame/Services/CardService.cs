using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;

namespace FunMatchGame.Interfaces
{
	public class CardService : ICardService
	{
		private readonly ISetService _setService;

		public CardService(ISetService setService)
		{
			_setService = setService;
		}

		public async Task<IEnumerable<Card>> GetRandomCardsAsync(Sets setId, int numberOfCards)
		{
			var cards = await _setService.GetCardsBySetIdAsync(setId);
			var r = new Random();
			var results = new List<Card>();
			for (int i = 0; i < numberOfCards; i++)
				results.Add(cards[r.Next(cards.Count)]);
			return results;
		}
	}
}