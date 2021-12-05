using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Core.Common;

namespace Brasileirao.Core.Models
{
  public class SiglaClube : ValueObject<SiglaClube>
  {
    public string Value { get; }

    private SiglaClube(string value)
    {
      Value = value;
    }

    public static Result<SiglaClube> Create(Maybe<string> siglaClubeOrNothing)
    {
      return siglaClubeOrNothing.ToResult("Sigla do Clube deve estar definido")
          .OnSuccess(siglaClube => siglaClube.Trim())
          .Ensure(siglaClube => !string.IsNullOrWhiteSpace(siglaClube), "Sigla do Clube não deve estar vazio")
          .Ensure(siglaClube => siglaClube.Length == 3, "A sigla do clube deve ter examente 3 caracteres")
          .Map(siglaClube => new SiglaClube(siglaClube));
    }

    protected override bool EqualsCore(SiglaClube other)
    {
      return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
      return Value.GetHashCode();
    }

    public static explicit operator SiglaClube(string siglaClube)
    {
      return Create(siglaClube).Value;
    }

    public static implicit operator string(SiglaClube siglaClube)
    {
      return siglaClube.Value;
    }
  }
}