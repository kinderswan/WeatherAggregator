//(function () {

//	var model = new ImageModel(prompt("image name"));
//	model.fetch({
//		success: function (x) {
//			$.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
//				var template = _.template(data);
//				var result = template({ model: x });
//				$("#content").append(result);
//			}, "html");

//		},
//		error: function (x) {
//			console.log(x);
//		}
//	});
//})();

//(function() {
//	var col = new CitiesCollection("Belarus");
//	col.fetch({
//		success: function(x) {
//			console.log(x);
//		}
//	});

//})();

//(function() {
//	var col = new CountriesCollection();
//	col.fetch({
//		success: function(x) {
//			console.log(x);
//		}
//	});

//})();

//(function() {
//	var col = new WeatherCollection("Belarus", "Minsk");
//	col.customFetch();
//	console.log(col);

//})();

$(function() { new IndexPageView() });