using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using FunMatchGame.Interfaces;
using FunMatchGame.Models;
using FunMatchGame.ViewModels;

namespace FunMatchGame.Controllers
{
	[RoutePrefix("Api/Games/Sets/{setId}/Cards")]
	public class CardsController : ApiController
	{
		private readonly ICardService _cardService;
		private readonly IMappingEngine _mappingEngine;

		public CardsController(IMappingEngine mappingEngine,
			ICardService cardService)
		{
			_mappingEngine = mappingEngine;
			_cardService = cardService;
		}

		[Route("{cardNumber}")]
		public async Task<IEnumerable<CardDto>> GetCardsAsync(Sets setId, int cardNumber)
		{
			var cards = await _cardService.GetRandomCardsAsync(setId, cardNumber);
			return _mappingEngine.Map<IEnumerable<CardDto>>(cards);
		}
	}
}