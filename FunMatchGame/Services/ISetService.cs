using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;

namespace FunMatchGame.Interfaces
{
	public interface ISetService
	{
		Task<IList<Card>> GetCardsBySetIdAsync(Sets setId);
	}
}