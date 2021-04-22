using System.Net;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using WeatherAndMoviesApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WeatherAndMoviesApp.Services
{
    public class DataFetcher
    {
        private readonly IConfiguration Configuration;
        private const string MOVIE_TITLE = "t";
        private const string CITY_NAME = "q";
        private const string UNITS = "units";
        private const string MOVIE_API_KEY = "apikey";
        private const string WEATHER_API_KEY = "appid";
        private readonly int fetchingFrequencyInMiliseconds;

        public List<WeatherForecast> Forecasts { get; private set; }
        public List<Movie> Movies { get; private set; }
        private Timer Timer { get; set; }

        private DataFetcher(IConfiguration configuration)
        {
            Movies = new List<Movie>();
            Forecasts = new List<WeatherForecast>();
            Configuration = configuration;
            fetchingFrequencyInMiliseconds = Configuration.GetValue<int>("FetchingFrequencyInMiliseconds");
        }

        // We use this mimic of a construtor to await the api call successfully
        public async static Task<DataFetcher> BuildDataFetcherAsync(IConfiguration configuration)
        {
            var dataFetcher = new DataFetcher(configuration);

            // Inital call to get data
            await dataFetcher.UpdateCache();
            dataFetcher.Timer = new Timer(x => dataFetcher.UpdateCache(), null, 0, dataFetcher.fetchingFrequencyInMiliseconds);

            return dataFetcher;
        }

        /* This function will be called by a constant interval to update our data.
         We use it to minimize calls to the API incase of bad connection. */
        private async Task UpdateCache()
        {
            await Task.WhenAll(UpdateWeatherCache(), UpdateMovieCache());
        }

        private async Task UpdateWeatherCache()
        {
            var cityNames = Configuration.GetSection("Weather").GetSection("Cities").Get<string[]>();
            var apiKey = Configuration.GetValue<string>("Weather:ApiKey");
            var units = Configuration.GetValue<string>("Weather:Units");
            var apiUrl = Configuration.GetValue<string>("Weather:ApiUrl");

            Forecasts =  await new ApiAccesser<WeatherForecast>(apiUrl).AccessApi(cityNames, CITY_NAME, new Dictionary<string, string> { { WEATHER_API_KEY, apiKey }, { UNITS, units } }) ?? Forecasts;
        }

        private async Task UpdateMovieCache()
        {
            var apiUrl = Configuration.GetValue<string>("Movie:ApiUrl");
            var movieNames = Configuration.GetSection("Movie").GetSection("Titles").Get<string[]>();
            var apiKey = Configuration.GetValue<string>("Movie:ApiKey");

            Movies =  await new ApiAccesser<Movie>(apiUrl).AccessApi(movieNames, MOVIE_TITLE, new Dictionary<string, string> { { MOVIE_API_KEY, apiKey } }) ?? Movies;
        }
    }
}
