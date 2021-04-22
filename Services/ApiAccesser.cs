using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WeatherAndMoviesApp.Services
{
    public class ApiAccesser<T> : IApiAccesser<T>
    {
        public string ApiUrl { get; private set; }

        public ApiAccesser(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        // Method gets parameter values to query (I.E. city name, movie name), parameter name, and a dictionary of other http parameters to add
        public async Task<List<T>> AccessApi(IEnumerable<string> searchParamList,string searchParamName, Dictionary<string,string> httpRequestParams = null)
        {
            var returnList = new List<T>();
            foreach (var param in searchParamList)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.QueryString.Add(searchParamName, param);

                        if (httpRequestParams != null && httpRequestParams.Any())
                        {
                            foreach (var httpParam in httpRequestParams)
                            {
                                client.QueryString.Add(httpParam.Key, httpParam.Value);
                            }
                        }

                        var response = await client.DownloadStringTaskAsync(ApiUrl);
                        var weatherForecast = JsonConvert.DeserializeObject<T>(response);
                        returnList.Add(weatherForecast);
                    }
                }

                catch (Exception e)
                {
                    // Log it to Logstash / DB / etc
                    Console.WriteLine(e.Message);
                }
            }

            return returnList;
        }
    }
}
