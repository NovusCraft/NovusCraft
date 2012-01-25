/* Author: Arnold Zokas */
$(document).ready(function() {
	$('pre code').each(function(i, e) { hljs.highlightBlock(e, '    '); });

	$('#blog-post-editor').each(function() { var editor = new BlogPostEditor(); });
});

var BlogPostEditor = Backbone.View.extend({
	el: "#blog-post-editor",
	initialize: function () {
		this.titleInput = $(this.el).find(".title");
		this.titlePreview = $(this.el).find(".titlePreview");

		this.contentInput = $(this.el).find(".content");
		this.contentPreview = $(this.el).find(".contentPreview");
	},
	events: {
		"keyup .title": "titleChanged",
		"keyup .content": "contentChanged"
	},
	titleChanged: function () {
		this.titlePreview.text(this.titleInput.val());
	},
	contentChanged: function () {
		this.contentPreview.html(this.contentInput.val());
	}
});