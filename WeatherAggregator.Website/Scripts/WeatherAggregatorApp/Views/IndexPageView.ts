class IndexPageView extends Backbone.View<Backbone.Model> {

	
	private imageView: ImageView;

	constructor(countryName:string, cityName:string, stateName?:string) {
		super();
		this.imageView = new ImageView(countryName, cityName, stateName);
	}

	render(): any {
		this.remove();
		this.imageView.render();
	}

	remove(): any {
		$("#wapp-city-image-description").remove();
		$(".wapp-weather-info-block-class").remove();
		$("#wapp-city-image-content").remove();
	}
} 