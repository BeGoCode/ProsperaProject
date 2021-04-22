using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using WeatherAndMoviesApp.Models;
using WeatherAndMoviesApp.Services;

namespace WeatherAndMoviesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        // The controller receives by DI an instance of the data fetcher for delayed invocation, and can only get the values of the forecasts.
        private readonly DataFetcher DataFetcher;
        
        public WeatherController(DataFetcher dataFetcher)
        {
            DataFetcher = dataFetcher;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return DataFetcher.Forecasts;
        }
    }
}
