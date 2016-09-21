using System;
using System.Net.Http;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using WeatherAggregator.Rest.Interfaces;

namespace WeatherAggregator.Rest.Tests
{
	[TestClass]
	public class HttpRequestorTests
	{
		private HttpClient httpClient;

		private Mock<ILog> logMock;

		private MockHttpMessageHandler mockHttp;
		private HttpRequestor requestor;

		[TestInitialize]
		public void Initialize()
		{
			this.mockHttp = new MockHttpMessageHandler();
			this.logMock = new Mock<ILog>();
			this.mockHttp.When("http://localhost/*").Respond("application/json", JsonConvert.SerializeObject(new TestResponse
			{
				Name = "Test",
				Surname = "Test"
			}));
			this.httpClient = new HttpClient(this.mockHttp);
			this.requestor = new HttpRequestor(this.httpClient, this.logMock.Object);
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

			this.mockHttp.VerifyNoOutstandingExpectation();
		}

		[TestMethod, TestCategory("RestRequestor")]
		[ExpectedException(typeof (ArgumentException))]
		public void PerformRequest_StringEmpty_ArgumentException()
		{
			this.requestor.PerformRequest<TestResponse>(string.Empty, HttpMethod.Get);
		}

		[TestMethod, TestCategory("RestRequestor")]
		[ExpectedException(typeof (ArgumentException))]
		public void PerformRequest_StringNull_ArgumentException()
		{
			this.requestor.PerformRequest<TestResponse>(null, HttpMethod.Get);
		}
	}
}