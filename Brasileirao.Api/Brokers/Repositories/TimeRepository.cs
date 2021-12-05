using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Api.Models.Context;
using Brasileirao.Core.Models;

namespace Brasileirao.Api.Brokers.Repositories
{
  public class TimeRepository : ITimeRepository
  {
    public IEnumerable<Time> GetAllTimes()
    {
      return new TodosTimes().ObterTodos();
    }
  }
}