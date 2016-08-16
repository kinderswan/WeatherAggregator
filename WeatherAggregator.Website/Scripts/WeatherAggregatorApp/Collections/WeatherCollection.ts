/// <reference path="../models/WeatherModel.ts" />

class WeatherCollection extends Backbone.Collection<WeatherModel> {

	private countryName: string;
	private cityName: string;
	private stateName: string;

	constructor(countryName: string, cityName: string, stateName?: string) {
		super();
		this.countryName = countryName;
		this.cityName = cityName;
		this.stateName = stateName;
	}

	customFetch(success?: Function, error?: Function): void {
		var self = this;
		for (var i = 0; i < UrlConstants.WeatherApiUrls.length; i++) {
			var weatherModel = new WeatherModel(this.buildUrl(UrlConstants.WeatherApiUrls[i]));
			weatherModel.fetch({
				success: function (model) {
					if (!model.get("City")) {
						return;
					}
					self.add(model);
					success(model);
				}
			});
			
			
		}
	}

	url: string;

	private buildUrl(uri: string): string {
		return this.stateName === undefined
			? UrlConstants.Hostname + uri + this.countryName + "/" + this.cityName
			: UrlConstants.Hostname + uri + this.countryName + "/" + this.stateName + "/" + this.cityName;
	}
} 