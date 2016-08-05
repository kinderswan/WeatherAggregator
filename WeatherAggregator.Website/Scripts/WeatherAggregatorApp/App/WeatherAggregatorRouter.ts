/// <reference path="../../typings/backbone/backbone.d.ts" />
/// <reference path="../views/IndexPageView.ts" />

class WeatherAggregatorRouter extends Backbone.Router {

	routes: any = {
		"": "indexRoute",
		"index": "indexRoute"
	};

	constructor(options?: Backbone.RouterOptions) {
		super(options);
		Backbone.Router.apply(this, arguments);

	}

	indexRoute() {
		new IndexPageView();
	}
}
var router = new WeatherAggregatorRouter();
Backbone.history.start();

