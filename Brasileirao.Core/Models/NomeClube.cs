using Brasileirao.Core.Common;

namespace Brasileirao.Core.Models
{
    public class NomeClube : ValueObject<NomeClube>
    {
        public string Value { get; }

        private NomeClube(string value)
        {
            Value = value;
        }

        public static Result<NomeClube> Create(Maybe<string> NomeClubeOrNothing)
        {
            return NomeClubeOrNothing.ToResult("Nome do Clube deve estar definido")
                .OnSuccess(nomeClube => nomeClube.Trim())
                .Ensure(nomeClube => !string.IsNullOrWhiteSpace(nomeClube), "Nome do Clube não deve estar vazio")
                .Ensure(nomeClube => nomeClube.Length <= 50, "Nome do Clube é muito longo")
                .Map(nomeClube => new NomeClube(nomeClube));
        }

        protected override bool EqualsCore(NomeClube other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator NomeClube(string nomeClube)
        {
            return Create(nomeClube).Value;
        }

        public static implicit operator string(NomeClube nomeClube)
        {
            return nomeClube.Value;
        }
    }
}
