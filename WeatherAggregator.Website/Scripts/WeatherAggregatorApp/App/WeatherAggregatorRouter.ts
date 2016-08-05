﻿/// <reference path="../../typings/backbone/backbone.d.ts" />
/// <reference path="../views/IndexPageView.ts" />
/// <reference path="../../utilgeolocation.ts" />

class WeatherAggregatorRouter extends Backbone.Router {
	private indexPageView: IndexPageView;

	routes: any = {
		"": "indexRoute",
		"(:country)/(:city)": "weatherRoute"
	};

	constructor(options?: Backbone.RouterOptions) {
		super(options);
		Backbone.Router.apply(this, arguments);

	}

	indexRoute() {
		var coords = new UtilGeolocation();
		navigator.geolocation.getCurrentPosition(function (location) {
			coords.codeLatLng(location.coords.latitude, location.coords.longitude);
		});

	}

	weatherRoute(country, city) {
		if (this.indexPageView !== undefined) {
			this.indexPageView.remove();
		}
		this.indexPageView = new IndexPageView();
		this.indexPageView.renderCityImage(country, city);
	}
}
var router = new WeatherAggregatorRouter();
Backbone.history.start();

