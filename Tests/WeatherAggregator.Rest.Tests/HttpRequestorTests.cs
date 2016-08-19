using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest.Tests
{
	[TestClass]
	public class HttpRequestorTests
	{
		private HttpRequestor requestor;

		private HttpClient httpClient;

		private MockHttpMessageHandler mockHttp;

		[TestInitialize]
		public void Initialize()
		{
			this.mockHttp = new MockHttpMessageHandler();
			mockHttp.When("http://localhost/*").Respond("application/json", JsonConvert.SerializeObject(new TestResponse
			{
				Name = "Test",
				Surname = "Test"
			}));
			this.httpClient = new HttpClient(mockHttp);
			this.requestor = new HttpRequestor(this.httpClient);
		}

		[TestCleanup]
		public void CleanUp()
		{
			this.httpClient.Dispose();
			this.requestor.Dispose();
			this.mockHttp.Clear();
		}

		[TestMethod, TestCategory("RestRequestor")]
		public void PerformRequest_Get_ShouldReturn_Response()
		{
			IRestResponse<TestResponse> result = this.requestor.PerformRequest<TestResponse>("http://localhost/api", HttpMethod.Get);
			TestResponse json = result.Data;
			Assert.AreEqual("Test", json.Name);
			Assert.AreEqual("Test", json.Surname);

			mockHttp.VerifyNoOutstandingExpectation();
		}

		[TestMethod, TestCategory("RestRequestor")]
		public void PerformRequest_Get_ShouldReturn_DefaultTypeValue()
		{
			this.mockHttp.Clear();
			this.mockHttp.When("http://localhost/*").Respond("application/json", "some unexpected values");
			IRestResponse<TestResponse> result = this.requestor.PerformRequest<TestResponse>("http://localhost/api", HttpMethod.Get);
			Assert.AreEqual(result.Data, default(TestResponse));

			mockHttp.VerifyNoOutstandingExpectation();
		}

	}
}
