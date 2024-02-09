using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private ILoggerManager _loggerManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggerManager loggerManager)
        {
            _logger = logger;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _loggerManager.LogInfo("Here is info message from our values controller.");
            _loggerManager.LogDebug("Here is debug message from our values controller."); 
            _loggerManager.LogWarn("Here is warn message from our values controller."); 
            _loggerManager.LogError("Here is an error message from our values controller.");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
