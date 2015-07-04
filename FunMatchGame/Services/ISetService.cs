using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;

namespace FunMatchGame.Interfaces
{
	public interface ISetService
	{
		Task<IEnumerable<Card>> GetCardsBySetIdAsync(Sets setId);
	}
}