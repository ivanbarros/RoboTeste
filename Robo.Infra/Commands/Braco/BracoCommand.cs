using MediatR;
using Robo.Domain.Entities;
using Robo.Domain.Enums;

namespace Robo.Infra.Commands.Braco
{
    public class BracoCommand : IRequest<BracoCommandResponse>
    {
        public Cotovelo Cotovelo { get; set; }
        public Pulso Pulso { get; set; }
        public EscolhaBracoEnum escolhaBraco {get;set;}
        
        
    }
}
