class ImageView extends Backbone.View<ImageModel> {
	
	private inputCountry: any;
	private inputState: any;
	private inputCity: any;

	private weatherblocksView: WeatherBlocksView;

	constructor(countryName: string, cityName: string, stateName?: string) {
		super();
		this.inputCountry = countryName;
		this.inputCity = cityName;
		this.inputState = stateName;

		this.weatherblocksView = new WeatherBlocksView(countryName, cityName, stateName);
		//this.render();
	}

	render(): any {
		var cityImage = new ImageModel(this.inputCountry + " " + this.inputCity, 960);
		var self = this;
		cityImage.fetch({
			success: function (image) {
				$.get("Scripts/WeatherAggregatorApp/Templates/CityImageTemplate.html", function (data) {
					var template = _.template(data);
					var result: string = template({
						model: image,
						countryName: self.inputCountry,
						cityName: self.inputCity
					});
					$("#wapp-city-image-placeHolder").append(result);
					self.weatherblocksView.render();
				}, "html");

			}
		});
	}
} 