class IndexPageView extends Backbone.View<Backbone.Model> {

	events(): any {
		return {
		};
	}

	inputCountry: any;
	inputState: any;
	inputCity: any;

	weatherContainer: HTMLElement;

	constructor() {
		super();
		//this.render();
	}

	render(): any {
		this.renderCityImage();
		return {};
	}

	renderCityImage(countryName?: string, cityName?: string) {
		var cityImage = new ImageModel(countryName + " " + cityName, 960);
		var self = this;
		cityImage.fetch({
			success: function (image) {
				$.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
					var template = _.template(data);
					var result:string = template({ model: image });
					$("#wapp-city-image-placeHolder").append(result);
					self.renderWeatherBlocks(countryName, cityName);
				}, "html");

			}
		});
	}

	renderWeatherBlocks(countryName: string, cityName: string) {
		var weatherCollection = new WeatherCollection(countryName, cityName);
		weatherCollection.customFetch(function (weatherModel) {
			$.get("Scripts/WeatherAggregatorApp/Templates/WeatherInfoBlockTemplate.html", function (data) {
				var template = _.template(data);
				var result: string = template({ model: weatherModel });
				$("#wapp-weather-info-row").append(result);
			}, "html");
		});
		
	}

	remove(): any {
		$("#wapp-city-image-content").remove();
		$(".wapp-weather-info-block-class").remove();
	}
} 