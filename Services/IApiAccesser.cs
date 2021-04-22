using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAndMoviesApp.Services
{
    interface IApiAccesser<T>
    {
        string ApiUrl { get; }
        Task<List<T>> AccessApi(IEnumerable<string> searchParamList, string searchParamName, Dictionary<string, string> httpRequestParams = null);
    }
}
