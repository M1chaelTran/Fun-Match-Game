using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;

namespace FunMatchGame.Repositories
{
	public interface ISetRepository
	{
		Task<IEnumerable<Card>> GetCardsBySetIdAsync(Sets setId);
	}
}