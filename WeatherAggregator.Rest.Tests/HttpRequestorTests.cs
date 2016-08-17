using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;

namespace WeatherAggregator.Rest.Tests
{
	[TestClass]
	public class HttpRequestorTests
	{
		private HttpRequestor requestor;

		private HttpClient httpClient;

		private MockHttpMessageHandler mockHttp;
		private string testResponse;

		[TestInitialize]
		public void Initialize()
		{
			this.testResponse = JsonConvert.SerializeObject(new TestResponse
			{
				Name = "Test",
				Surname = "Test"
			});

			this.mockHttp = new MockHttpMessageHandler();
			mockHttp.When("http://localhost/*").Respond("application/json", this.testResponse);
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

		[TestMethod]
		public void ShouldReturnResponseIfRequestedByGetVerb()
		{
			var result = this.requestor.PerformRequest<TestResponse>("http://localhost/api", HttpMethod.Get);
			var json = result.Data;
			Assert.AreEqual("Test", json.Name);
			Assert.AreEqual("Test", json.Surname);
			mockHttp.VerifyNoOutstandingExpectation();
		}

		[TestMethod]
		public void ShouldReturnDefaultTypeValueIfResponseCantBeObtained()
		{
			this.mockHttp.Clear();
			this.mockHttp.When("http://localhost/*").Respond("application/json", "some unexpected values");
			var result = this.requestor.PerformRequest<TestResponse>("http://localhost/api", HttpMethod.Get);
			Assert.AreEqual(result.Data, default(TestResponse));
			mockHttp.VerifyNoOutstandingExpectation();
		}

	}
}
