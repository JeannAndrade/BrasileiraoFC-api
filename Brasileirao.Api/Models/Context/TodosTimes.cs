using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Core.Models;

namespace Brasileirao.Api.Models.Context
{
  public class TodosTimes
  {
    private readonly List<Time> times;

    public TodosTimes()
    {
      times = new List<Time>();
      times.AddRange(new Time[] {
        new Time
        {
          Nome = (NomeClube)"Flamengo",
          Estado = Estado.RJ,
          Sigla = (SiglaClube)"FLA"
        },
        new Time
        {
          Nome = (NomeClube)"Vasco",
          Estado = Estado.RJ,
          Sigla = (SiglaClube)"VAS"
        }
      });
    }

    public List<Time> ObterTodos()
    {
      return times;
    }
  }
}