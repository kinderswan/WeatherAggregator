class WeatherModel extends Backbone.Model {

	constructor(url?: string) {
		super();
		this.url = url;
		this.defaults();
	}

	defaults(): { Temperature: number; Humidity: string; WindSpeed: number; WindDegrees: number; Feelslike: string; Country: string; State: string; City: string, WeatherDescription: string } {
		return {
			Temperature: 0,
			Humidity: "",
			WindSpeed: 0,
			WindDegrees: 0,
			Feelslike: "",
			Country: "",
			State: "",
			City: "",
			WeatherDescription:""
		}
	}

	url: string;

} 