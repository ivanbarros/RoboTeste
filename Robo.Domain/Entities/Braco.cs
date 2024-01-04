namespace Robo.Domain.Entities
{
    public class Braco : BaseEntity
    {
       
        public Cotovelo Cotovelo { get; set; }
        public Pulso Pulso { get; set; }
        public string Lado { get; set; }
    }
}
