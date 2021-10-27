using Brasileirao.Core.Common;

namespace Brasileirao.Core.Models
{
    public class Time : Entity
    {
        public NomeClube Nome { get; set; }
        public Estado Estado { get; set; }
        public byte[] Escudo { get; set; }
    }
}
