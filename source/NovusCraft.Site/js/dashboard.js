/* Author: Arnold Zokas */
$(document).ready(function() {
	$('#blog-post-editor').each(function() { var editor = new BlogPostEditor(); });
});

var BlogPostEditor = Backbone.View.extend({
	el: "#blog-post-editor",
	initialize: function() {
		this.titleInput = $(this.el).find(".title");
		this.titlePreview = $(this.el).find(".titlePreview");

		this.categoryTitleInput = $(this.el).find(".category");
		this.categoryTitlePreview = $(this.el).find(".categoryPreview");

		// initialise Pagedown
		var converter = new Markdown.Converter();
		var editor = new Markdown.Editor(converter);
		editor.run();

		// if in edit mode - force validation to display correct validity status
		if (this.isInEditMode())
			$(this.el).find("form").valid();
	},
	events: {
		"keyup .title": "titleChanged",
		"keyup .category": "categoryTitleChanged"
	},
	titleChanged: function() {
		this.titlePreview.text(this.titleInput.val());
	},
	categoryTitleChanged: function() {
		this.categoryTitlePreview.text(this.categoryTitleInput.val());
	},
	isInEditMode: function() {
		return this.titleInput.val() != "";
	}
});