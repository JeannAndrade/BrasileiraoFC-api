using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Api.DataTransferObjects
{
  public class TimeDTO
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public string Estado { get; set; }
  }
}