// # Copyright © 2011, Novus Craft
// # All rights reserved. 

using System;
using Machine.Specifications;
using Moq;
using NovusCraft.Data.Blog;
using NovusCraft.Web.Controllers;

namespace NovusCraft.Specifications.WebSpecs.ControllerSpecs.BlogControllerSpecs
{
	public abstract class blog_controller_spec
	{
		protected static BlogController controller;

		Establish context = () =>
			{
				var repository = new Mock<IBlogCategoryRepository>();
				repository.Setup(r => r.GetBlogPost("test-slug-1")).Returns(new BlogPost
				                                                            	{
				                                                            		Title = "Test Post Title 1",
				                                                            		Content = "Test Post Content 1",
				                                                            		Category = new BlogPostCategory
				                                                            		           	{
				                                                            		           		Title = "Category 1"
				                                                            		           	},
				                                                            		PublishedOn = new DateTimeOffset(2011, 11, 10, 09, 08, 07, TimeSpan.Zero)
				                                                            	});

				controller = new BlogController(repository.Object);
			};
	}
}