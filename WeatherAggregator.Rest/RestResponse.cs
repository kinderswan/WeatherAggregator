using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class RestResponse<T> : IRestResponse<T>
	{
		private readonly ILog log = LogManager.GetLogger(typeof (RestResponse<T>).Name);

		public RestResponse()
		{
		}

		public RestResponse(HttpResponseMessage httpResponseMessage)
			: this()
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "has been called");
			this.StatusCode = httpResponseMessage.StatusCode;
			this.Data = this.GetDataFromResponseContent(httpResponseMessage.Content);
		}

		public HttpStatusCode StatusCode { get; private set; }

		public T Data { get; private set; }

		private T GetDataFromResponseContent(HttpContent responseContent)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");
			string responseString = Task.Run(() => responseContent.ReadAsStringAsync()).Result;
			return this.JsonTryDeserialize(responseString);
		}

		private T JsonTryDeserialize(string responseString)
		{
			this.log.InfoFormat(CultureInfo.InvariantCulture, "method has been called");

			T result;

			try
			{
				result = JsonConvert.DeserializeObject<T>(responseString);
			}
			catch (JsonSerializationException exception)
			{
				this.log.FatalFormat(CultureInfo.InvariantCulture, "JsonTryDeserialize threw an error {0} {1}", exception.Data,
					exception.Message);
				return default(T);
			}

			return result;
		}
	}
}