class WeatherBlocksView extends Backbone.View<Backbone.Model> {

	events(): any {
		return {

		};
	}

	private inputCountry: any;
	private inputState: any;
	private inputCity: any;

	constructor(countryName: string, cityName: string, stateName?: string) {
		super();
		this.inputCountry = countryName;
		this.inputCity = cityName;
		this.inputState = stateName;
	}

	render():any {
		var weatherCollection = new WeatherCollection(this.inputCountry, this.inputCity, this.inputState);
		weatherCollection.customFetch(function (weatherModel) {
			$.get("Scripts/WeatherAggregatorApp/Templates/WeatherInfoBlockTemplate.html", function (data) {
				var template = _.template(data);
				var result: string = template({
					model: weatherModel
				});
				$("#wapp-weather-info-row").append(result);
			}, "html");
		});

	}
} 