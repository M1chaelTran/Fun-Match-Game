using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using FunMatchGame;
using FunMatchGame.Interfaces;
using FunMatchGame.Repositories;

[assembly: PreApplicationStartMethod(typeof (IocRegistration), "Register")]

namespace FunMatchGame
{
	public class IocRegistration
	{
		public static void Register()
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<SetRepository>().As<ISetRepository>().SingleInstance();

			builder.RegisterType<SetService>().As<ISetService>().InstancePerRequest();
			builder.RegisterType<CardService>().As<ICardService>().InstancePerRequest();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			// reg web modules
			builder.RegisterModule(new AutofacWebTypesModule());

			// reg filter modules
			builder.RegisterFilterProvider();

			//reg mapping engine
			builder.Register(c => Mapper.Engine).As<IMappingEngine>().SingleInstance();

			var container = builder.Build();

			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}