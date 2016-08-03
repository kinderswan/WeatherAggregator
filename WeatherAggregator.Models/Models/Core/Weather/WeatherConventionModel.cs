namespace WeatherAggregator.Models.Models.Core.Weather
{
	public class WeatherConventionModel
	{
		public double Temperature { get; set; }

		public string Humidity { get; set; }

		public double WindSpeed { get; set; }

		public double WindDegrees { get; set; }

		public string Feelslike { get; set; }

		public string Country { get; set; }

		public string State { get; set; }

		public string City { get; set; }
	}
}
