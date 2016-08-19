/// <reference path="../typings/backbone/backbone.d.ts" />

class UrlConstants {
	public static Hostname: string = "https://10.143.12.195:888/";
	public static CityApiUrl: string = "api/location/getcities/";
	public static CountryApiUrl: string = "api/location/getcountries/";
	public static ImageApiUrl: string = "api/images/getimage/";

	public static WeatherApiUrls: Array<string> = [
		"api/weather/wunderground/",
		"api/weather/openweathermap/"
	];
} 
