class IndexPageView extends Backbone.View<Backbone.Model> {

	events(): any {
		return {
			"click #content": "clickContent"
		};
	}

	inputCountry: any;
	inputState: any;
	inputCity: any;

	weatherContainer: HTMLElement;

	constructor() {
		super();

		this.render();
	}

	render(): any {
		this.renderCityImage("Belarus", "Minsk");
		return {};
	}

	renderCityImage(countryName: string, cityName: string) {
		var cityImage = new ImageModel(countryName + " " + cityName, 960);
		var self = this;
		cityImage.fetch({
			success: function (x) {
				$.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
					var template = _.template(data);
					var result:string = template({ model: x });
					$("#content").append(result);
				}, "html");

			}
		});
	}


	clickContent(): void {
		alert(1);
	}
} 