using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAndMoviesApp.Models;
using WeatherAndMoviesApp.Services;

namespace WeatherAndMoviesApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // The controller receives by DI an instance of the data fetcher for delayed invocation, and can only get the values of the forecasts.
        private readonly DataFetcher DataFetcher;

        public MovieController(DataFetcher dataFetcher)
        {
            DataFetcher = dataFetcher;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return DataFetcher.Movies;
        }
    }
}