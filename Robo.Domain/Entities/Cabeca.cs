using Robo.Domain.Enums;

namespace Robo.Domain.Entities
{
    public class Cabeca : BaseEntity
    {
        
        public Rotacao Rotacao { get; set; }
        public Inclinacao Inclinacao { get; set; }
    }

}
