using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Api.Brokers.Loggings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brasileirao.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


    private readonly ILoggingBroker _logger;

    public WeatherForecastController(ILoggingBroker logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {

      _logger.LogInformation("Here is info message from our values controller.");
      _logger.LogDebug("Here is debug message from our values controller.");
      _logger.LogWarning("Here is warn message from our values controller.");
      _logger.LogError(new Exception("Um erro incontestável aconteceu na aplicação"), "Here is an error message from our values controller.");

      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}
