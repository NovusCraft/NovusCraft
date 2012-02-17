// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using AutoMapper;
using Machine.Specifications;
using NovusCraft.Infrastructure;

namespace NovusCraft.Specifications.InfrastructureSpecs.AutoMapperConfiguratorSpecs
{
	[Subject(typeof(AutoMapperConfigurator))]
	public class when_initialised
	{
		Because of = () => AutoMapperConfigurator.Initialise();

		It should_be_configured_correctly =
			() => Mapper.AssertConfigurationIsValid();
	}
}