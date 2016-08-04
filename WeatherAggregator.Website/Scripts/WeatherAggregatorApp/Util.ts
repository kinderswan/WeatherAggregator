/// <reference path="../typings/backbone/backbone.d.ts" />

class Util {
	public static Hostname: string = "http://localhost:555/";
	public static CityApiUrl: string = "api/location/getcities/";
	public static CountryApiUrl: string = "/api/location/getcountries/";
	public static ImageApiUrl: string = "api/images/getimage/";

	public static WeatherApiUrls: Array<string> = [
		"api/weather/wunderground",
		"api/weather/openweathermap"
	];
} 
