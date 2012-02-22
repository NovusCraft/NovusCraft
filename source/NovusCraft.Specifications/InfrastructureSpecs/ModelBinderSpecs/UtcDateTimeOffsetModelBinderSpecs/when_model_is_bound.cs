// # Copyright © 2011-2012, Novus Craft
// # All rights reserved. 

using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using Machine.Specifications;
using NovusCraft.Infrastructure.ModelBinders;

namespace NovusCraft.Specifications.InfrastructureSpecs.ModelBinderSpecs.UtcDateTimeOffsetModelBinderSpecs
{
	[Subject(typeof(UtcDateTimeOffsetModelBinder))]
	public class when_model_is_bound
	{
		static DateTimeOffset model;

		Because of = () =>
		{
			var binder = new UtcDateTimeOffsetModelBinder();

			var modelBindingContext = new ModelBindingContext();
			modelBindingContext.ModelName = "TestModelName";

			var nameValueCollection = new NameValueCollection();
			nameValueCollection.Add("TestModelName", "22 February 2012 21:56");
			modelBindingContext.ValueProvider = new NameValueCollectionValueProvider(nameValueCollection, null);

			model = (DateTimeOffset)binder.BindModel(null, modelBindingContext);
		};

		It should_return_utc_aligned_datetimeoffset =
			() => model.ShouldEqual(new DateTimeOffset(2012, 2, 22, 21, 56, 0, 0, TimeSpan.Zero));
	}
}