// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using AutoMapper;
using NovusCraft.Model;
using NovusCraft.Web.ViewModels;

namespace NovusCraft.Infrastructure
{
	public static class AutoMapperConfigurator
	{
		public static void Initialise()
		{
			Mapper.CreateMap<CreateBlogPostModel, BlogPost>().ForMember(m => m.Id, options => options.Ignore());
			Mapper.CreateMap<UpdateBlogPostModel, BlogPost>();

			Mapper.AssertConfigurationIsValid();
		}
	}
}