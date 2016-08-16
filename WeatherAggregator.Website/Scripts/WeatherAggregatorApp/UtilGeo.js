var geocoder;

if (navigator.geolocation) {
	navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
}
//Get the latitude and the longitude;
function successFunction(position) {
	var lat = position.coords.latitude;
	var lng = position.coords.longitude;
	codeLatLng(lat, lng)
}

function errorFunction() {
	alert("Geocoder failed");
}

function initialize() {
	geocoder = new google.maps.Geocoder();
}

function codeLatLng(lat, lng) {

	var latlng = new google.maps.LatLng(lat, lng);
	geocoder.geocode({ 'latLng': latlng }, function(results, status) {
		if (status == google.maps.GeocoderStatus.OK) {
			console.log(results)
			if (results[1]) {
				for (var i = 0; i < results[0].address_components.length; i++) {
					for (var b = 0; b < results[0].address_components[i].types.length; b++) {
						if (results[0].address_components[i].types[b] == "administrative_area_level_1") {
							city = results[0].address_components[i];
							break;
						}
					}
				}
				//city data
				alert(city.short_name + " " + city.long_name)
			} else {
				alert("No results found");
			}
		} else {
			alert("Geocoder failed due to: " + status);
		}
	});
}