/// <reference path="typings/googlemaps/google.maps.d.ts" />

class UtilGeolocation {
	geocoder;
	cityName;
	countryName;

	constructor() {
		this.geocoder = new google.maps.Geocoder();
	}

	successFunction(position) {
		var lat = position.coords.latitude;
		var lng = position.coords.longitude;
		this.codeLatLng(lat, lng);
	}

	codeLatLng(lat, lng) : CityGeoModel {
		var latlng = new google.maps.LatLng(lat, lng);
		var cityGeoResult: CityGeoModel;
		var self = this;
		this.geocoder.geocode({ 'latLng': latlng }, function (results, status) {
			if (status === google.maps.GeocoderStatus.OK) {
				console.log(results);
				if (results[1]) {
					for (var i = 0; i < results[0].address_components.length; i++) {
						for (var b = 0; b < results[0].address_components[i].types.length; b++) {
							if (results[0].address_components[i].types[b] === "locality") {
								self.cityName = results[0].address_components[i].short_name;
								break;
							}
						}

						for (var c = 0; c < results[0].address_components[i].types.length; c++) {
							if (results[0].address_components[i].types[c] === "country") {
								self.countryName = results[0].address_components[i].long_name;
								break;
							}
						}
					}
					//city data
					cityGeoResult = new CityGeoModel(self.cityName, self.countryName);
					console.log(cityGeoResult);
					alert(self.countryName);
					alert(self.countryName);
				}
			}
		});

		return cityGeoResult;
	}
}

class CityGeoModel {
	public CityName: string;
	public CountryName: string;

	constructor(city, country) {
		this.CityName = city;
		this.CountryName = country;
	}
}