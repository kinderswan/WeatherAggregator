/// <reference path="../../typings/backbone/backbone.d.ts" />

class WeatherInfo extends Backbone.Model {
	private cityName: string;

	constructor() {
		super();
	}

	get CityName() {
		return this.cityName;
	}

	set CityName(value) {
		this.cityName = value;
	}
} 