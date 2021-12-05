using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Api.Brokers.Loggings;
using Brasileirao.Api.Brokers.Repositories;
using Brasileirao.Api.DataTransferObjects;
using Brasileirao.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brasileirao.Api.Controllers
{
  [ApiController]
  [Route("api/times")]
  public class TimesController : ControllerBase
  {
    private readonly ILoggingBroker _logger;
    private readonly ITimeRepository _timeRepository;

    public TimesController(ILoggingBroker logger, ITimeRepository timeRepository)
    {
      _logger = logger;
      _timeRepository = timeRepository;
    }

    [HttpGet]
    public IActionResult GetTimes()
    {
      _logger.LogInformation("Here is info message from our values controller.");
      _logger.LogDebug("Here is debug message from our values controller.");
      _logger.LogWarning("Here is warn message from our values controller.");

      var times = _timeRepository.GetAllTimes();
      var timesDTO = times.Select(c => new TimeDTO
      {
        Id = c.Id,
        Nome = c.Nome,
        Sigla = c.Sigla,
        Estado = c.Estado.ToString()
      }).ToList();

      return Ok(timesDTO);
    }
  }
}
