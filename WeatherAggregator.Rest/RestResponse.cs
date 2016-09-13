using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class RestResponse<T> : IRestResponse<T>
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(RestResponse<T>).Name);

		public HttpStatusCode StatusCode { get; private set; }

		public T Data { get; private set; }

		public RestResponse() { }

		public RestResponse(HttpResponseMessage httpResponseMessage)
			: this()
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.StatusCode = httpResponseMessage.StatusCode;
			this.Data = this.GetDataFromResponseContent(httpResponseMessage.Content);
		}

		private T GetDataFromResponseContent(HttpContent responseContent)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			string responseString = Task.Run(() => responseContent.ReadAsStringAsync()).Result;
			return this.JsonTryDeserialize(responseString);
		}

		private T JsonTryDeserialize(string responseString)
		{
			log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			T result;

			try
			{
				result = JsonConvert.DeserializeObject<T>(responseString);
			}
			catch (JsonSerializationException exception)
			{
				log.FatalFormat(CultureInfo.InvariantCulture, "JsonTryDeserialize threw an error {0} {1}", exception.Data, exception.Message);
				return default(T);
			}

			return result;
		}
	}
}
