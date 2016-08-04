/// <reference path="../../typings/backbone/backbone.d.ts" />

class WeatherModel extends Backbone.Model {
	defaults(): { temperature: number;humidity: string;windSpeed: number;windDegrees: number;feelslike: string;country: string;state: string;city: string } {
		return {
			temperature: 0,
			humidity: "",
			windSpeed: 0,
			windDegrees: 0,
			feelslike: "",
			country: "",
			state: "",
			city: ""
		}
	}

	initialize(): void {
		var util = new Util();
	}

	clear(): void {

		this.destroy();
	}

} 