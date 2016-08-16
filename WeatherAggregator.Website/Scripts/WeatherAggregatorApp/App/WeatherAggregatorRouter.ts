/// <reference path="../../typings/backbone/backbone.d.ts" />
/// <reference path="../views/IndexPageView.ts" />
/// <reference path="../../utilgeolocation.ts" />

class WeatherAggregatorRouter extends Backbone.Router {
	private indexPageView: IndexPageView;
	private locationView: LocationView;

	routes: any = {
		"": "indexRoute",
		"(:country)/(:city)": "weatherRoute",
		"(:country)/(:state)/(:city)": "weatherStateRoute"
	};

	constructor(options?: Backbone.RouterOptions) {
		super(options);
		Backbone.Router.apply(this, arguments);

		this.locationView = new LocationView();
		this.locationView.render();
	}

	indexRoute() {
		var coords = new UtilGeolocation();
		navigator.geolocation.getCurrentPosition(function (location) {
			coords.codeLatLng(location.coords.latitude, location.coords.longitude);
		});
		
	}

	weatherRoute(country, city) {
		LocationView.inputCountry = country;
		LocationView.inputCity = city;
		this.indexPageView = new IndexPageView(country, city);
		this.indexPageView.remove();
		this.indexPageView.render();
	}

	weatherStateRoute(country, state, city) {
		LocationView.inputCountry = country;
		LocationView.inputCity = city;
		LocationView.inputState = state;
		this.indexPageView = new IndexPageView(country, city, state);
		this.indexPageView.remove();
		this.indexPageView.render();
	}
}
var router = new WeatherAggregatorRouter();
Backbone.history.start();

