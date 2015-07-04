using AutoMapper;
using FunMatchGame.Maps;

namespace FunMatchGame
{
	public class MapperRegistration
	{
		public static void Register()
		{
			Mapper.AddProfile<CardMaps>();
		}
	}
}