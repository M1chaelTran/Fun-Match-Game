using System.Collections.Generic;
using System.Threading.Tasks;
using FunMatchGame.Models;
using FunMatchGame.Repositories;

namespace FunMatchGame.Interfaces
{
	public class SetService : ISetService
	{
		private readonly ISetRepository _setRepository;

		public SetService(ISetRepository setRepository)
		{
			_setRepository = setRepository;
		}

		public Task<IEnumerable<Card>> GetCardsBySetIdAsync(Sets setId)
		{
			return _setRepository.GetCardsBySetIdAsync(setId);
		}
	}
}