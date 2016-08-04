(function () {

	var model = new ImageModel("sunny");
	model.fetch({
		success: function (x) {
			$.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
				var template = _.template(data);
				var result = template({ model: x });
				$("#content").append(result);
			}, "html");

		},
		error: function (x) {
			console.log(x);
		}
	});
})();