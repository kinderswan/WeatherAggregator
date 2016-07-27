using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAggregator.Rest.HttpWebHelpers;

namespace WeatherAggregator.Rest.Interfaces
{
    public interface IHttpWebRequestor<out T> where T : class
    {
        T PerformRequest(string url, HttpMethod method);
    }
}
