/// <reference path="../models/WeatherModel.ts" />

class WeatherCollection extends Backbone.Collection<WeatherModel> {

	private countryName: string;
	private cityName: string;
	private stateName: string;

	constructor(countryName: string, cityName: string, stateName: string) {
		super();
		this.countryName = countryName;
		this.cityName = cityName;
		this.stateName = stateName;
	}

	customFetch(): void {
		for (var i = 0; i < Util.WeatherApiUrls.length; i++) {
			var weatherModel = new WeatherModel(this.buildUrl(Util.WeatherApiUrls[i]));
			weatherModel.fetch();
			this.add(weatherModel);
		}
	}

	url: string;

	private buildUrl(uri: string): string {
		return this.stateName === undefined
			? Util.Hostname + uri + this.countryName + "/" + this.cityName
			: Util.Hostname + uri + this.countryName + "/" + this.stateName + "/" + this.cityName;
	}
} 