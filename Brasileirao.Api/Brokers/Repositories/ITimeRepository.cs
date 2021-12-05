using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Core.Models;

namespace Brasileirao.Api.Brokers.Repositories
{
  public interface ITimeRepository
  {
    IEnumerable<Time> GetAllTimes();
  }
}