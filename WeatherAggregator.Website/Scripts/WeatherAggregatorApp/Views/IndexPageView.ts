class IndexPageView extends Backbone.View<Backbone.Model> {

	private inputCountry: string;
	private inputState: string;
	private inputCity: string;

	private locationView: LocationView;
	private imageView: ImageView;

	constructor(countryName:string, cityName:string, stateName?:string) {
		super();
		this.inputCountry = countryName;
		this.inputState = stateName;
		this.inputCity = cityName;
		this.locationView = new LocationView(countryName, cityName, stateName);
		this.imageView = new ImageView(countryName, cityName, stateName);
	}

	render(): any {
		this.locationView.render();
		this.imageView.render();
	}

	remove(): any {
		$("#wapp-city-image-content").remove();
		$("#wapp-city-image-description").remove();
		$("#wapp-location-countries").remove();
		$(".wapp-weather-info-block-class").remove();
	}
} 