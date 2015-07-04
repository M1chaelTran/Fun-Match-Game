using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;

namespace FunMatchGame.Interfaces
{
	public interface ICardService
	{
		Task<IEnumerable<Card>> GetRandomCardsAsync(Sets setId, int numberOfCards);
	}
}