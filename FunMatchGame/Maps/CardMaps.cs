using AutoMapper;
using FunMatchGame.Models;
using FunMatchGame.ViewModels;

namespace FunMatchGame.Maps
{
	public class CardMaps : Profile
	{
		protected override void Configure()
		{
			CreateMap<Card, CardDto>();
		}
	}
}