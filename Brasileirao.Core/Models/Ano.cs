using Brasileirao.Core.Common;

namespace Brasileirao.Core.Models
{
  public class Ano : ValueObject<Ano>
  {
    public int Value { get; }

    private Ano(int value)
    {
      Value = value;
    }

    public static Result<Ano> Create(int anoCampeonato, int anoCorrente)
    {
      var anoPosteriorAoCorrente = anoCorrente + 1;
      return Result.Ok<int>(anoCampeonato)
          .Ensure(anoCampeonato => anoCampeonato > 2020, "O ano do campoenato deve ser maior que 2020")
          .Ensure(anoCampeonato => anoCampeonato <= anoPosteriorAoCorrente, $"O ano do campoenato deve ser menor que {anoPosteriorAoCorrente}")
          .Map(anoCampeonato => new Ano(anoCampeonato));
    }


    protected override bool EqualsCore(Ano other)
    {
      return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
      return Value.GetHashCode();
    }

    public static implicit operator int(Ano ano)
    {
      return ano.Value;
    }
  }
}
