/// <reference path="typings/googlemaps/google.maps.d.ts" />
var UtilGeolocation = (function () {
    function UtilGeolocation() {
        this.geocoder = new google.maps.Geocoder();
    }
    UtilGeolocation.prototype.successFunction = function (position) {
        var lat = position.coords.latitude;
        var lng = position.coords.longitude;
        this.codeLatLng(lat, lng);
    };
    UtilGeolocation.prototype.codeLatLng = function (lat, lng) {
        var latlng = new google.maps.LatLng(lat, lng);
        var cityGeoResult;
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
    };
    return UtilGeolocation;
}());
var CityGeoModel = (function () {
    function CityGeoModel(city, country) {
        this.CityName = city;
        this.CountryName = country;
    }
    return CityGeoModel;
}());
//# sourceMappingURL=UtilGeolocation.js.map