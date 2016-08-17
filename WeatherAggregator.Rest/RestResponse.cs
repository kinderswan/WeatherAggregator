﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest
{
	public class RestResponse<T> : IRestResponse<T>
	{
		public HttpStatusCode StatusCode { get; private set; }

		public T Data { get; private set; }

		public RestResponse() { }

		public RestResponse(HttpResponseMessage httpResponseMessage)
			: this()
		{
			this.StatusCode = httpResponseMessage.StatusCode;
			this.Data = this.GetDataFromResponseContent(httpResponseMessage.Content);
		}

		private T GetDataFromResponseContent(HttpContent responseContent)
		{
			string responseString = Task.Run(() => responseContent.ReadAsStringAsync()).Result;
			return this.JsonTryDeserialize(responseString);
		}

		private T JsonTryDeserialize(string responseString)
		{
			T result;

			try
			{
				result = JsonConvert.DeserializeObject<T>(responseString);
			}
			catch
			{
				return default(T);
			}

			return result;
		}
	}
}
