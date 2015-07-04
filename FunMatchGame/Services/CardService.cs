using System.Collections.Generic;
using System.Linq;
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
			cards = cards.Take(numberOfCards);
			// TODO: Randomise it!
			return cards;
		}
	}
}