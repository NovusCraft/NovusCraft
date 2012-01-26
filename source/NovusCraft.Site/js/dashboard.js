/* Author: Arnold Zokas */
$(document).ready(function() {
	$('#blog-post-editor').each(function() { var editor = new BlogPostEditor(); });

	$("#contextual-actions a.delete").requireConfirmation({ text: "Are you sure you want to delete this permanently?" });
	$("#contextual-actions a.delete").ajaxButton({
		success: function(data) {
			window.location = data.redirectTo;
		}
	});

	$(".datetime-picker").datetimepicker({
		hourGrid: 4,
		minuteGrid: 10,
		dateFormat: "dd MM yy",
		showButtonPanel: false
	});
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


/*	PLUGIN
	Name:			requireConfirmation
	Description:	Adds a click event that displays confirmation dialog on target items
*/
(function($, window, document, undefined) {
	var pluginName = 'requireConfirmation';
	var defaults = { };

	function plugin(element, options) {
		this.element = element;
		this.options = $.extend({ }, defaults, options);
		this._defaults = defaults;
		this._name = pluginName;

		this.init();
	}

	plugin.prototype.init = function() {
		var options = this.options;
		$(this.element).click(function(e) {
			var response = confirm(options.text);
			if (response)
				return;

			e.stopPropagation();
			e.preventDefault();
		});
	};

	$.fn[pluginName] = function(options) {
		return this.each(function() {
			if (!$.data(this, 'plugin_' + pluginName)) {
				$.data(this, 'plugin_' + pluginName,
					new plugin(this, options));
			}
		});
	};
})(jQuery, window, document);


/*	PLUGIN
	Name:			ajaxButton
	Description:	Intercepts default hyperlink and, instead, executes an ajax request
*/
(function($, window, document, undefined) {
	var pluginName = 'ajaxButton';
	var defaults = {
		verb: "DELETE"
	};

	function plugin(element, options) {
		this.element = element;
		this.options = $.extend({ }, defaults, options);
		this._defaults = defaults;
		this._name = pluginName;

		this.init();
	}

	plugin.prototype.init = function() {
		var options = this.options;
		$(this.element).click(function(e) {
			if (e.isPropagationStopped())
				return;

			var targetUrl = $(this).attr("href");
			var antiForgeryToken = $('input[name=__RequestVerificationToken]').val();

			$.ajax({
				url: targetUrl,
				data: { __RequestVerificationToken: antiForgeryToken },
				type: options.verb,
				success: function(data) {
					options.success(data);
				}
			});

			e.preventDefault();
		});
		;
	};

	$.fn[pluginName] = function(options) {
		return this.each(function() {
			if (!$.data(this, 'plugin_' + pluginName)) {
				$.data(this, 'plugin_' + pluginName,
					new plugin(this, options));
			}
		});
	};
})(jQuery, window, document);