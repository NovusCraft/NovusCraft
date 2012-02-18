// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using Machine.Specifications;
using NovusCraft.Infrastructure;

namespace NovusCraft.Specifications.InfrastructureSpecs.ConfigSpecs
{
	[Subject(typeof(Config))]
	public class when_string_setting_is_requested
	{
		It should_set_error_message_resource_type =
			() => Config.Get("Setting").ShouldEqual("Setting.Value");
	}
}