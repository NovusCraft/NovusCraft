// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System.Web.Routing;
using Machine.Specifications;
using NovusCraft.Infrastructure;
using NovusCraft.Specifications.SpecUtils;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.InfrastructureSpecs.RouteConfiguratorSpecs
{
	[Subject(typeof(RouteConfigurator))]
	public class when_initialised
	{
		Because of = () => RouteConfigurator.Initialise();

		Cleanup after = () => RouteTable.Routes.Clear();

		It should_register_axd_ignore_route =
			() => "resource.axd".ShouldBeIgnored();

		It should_register_xml_sitemap_route =
			() => "~/sitemap.xml".ShouldMapTo<HomeController>(controller => controller.XmlSitemap());

		It should_register_404_route =
			() => "~/this-page-does-not-exist".ShouldMapTo<HomeController>(controller => controller.PageNotFound());
	}
}