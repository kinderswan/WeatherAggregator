class IndexPageView extends Backbone.View<Backbone.Model> {

	events(): any {
		return {
		};
	}

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
		this.locationView = new LocationView();
		this.imageView = new ImageView(countryName, cityName, stateName);
		this.render();
	}

	render(): any {
		this.imageView.render();
	}

	remove(): any {
		$("#wapp-city-image-content").remove();
		$("#wapp-city-image-description").remove();
		$(".wapp-weather-info-block-class").remove();
	}
} 