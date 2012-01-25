/* Author: Arnold Zokas */
$(document).ready(function() {
	$('pre code').each(function(i, e) { hljs.highlightBlock(e, '    '); });

	$('#blog-post-editor').each(function() { var editor = new BlogPostEditor(); });
});

var BlogPostEditor = Backbone.View.extend({
	el: "#blog-post-editor",
	initialize: function() {
		this.titleInput = $(this.el).find(".title");
		this.titlePreview = $(this.el).find(".titlePreview");

		var converter = new Markdown.Converter();
		var editor = new Markdown.Editor(converter);
		editor.run();
	},
	events: {
		"keyup .title": "titleChanged"
	},
	titleChanged: function() {
		this.titlePreview.text(this.titleInput.val());
	}
});