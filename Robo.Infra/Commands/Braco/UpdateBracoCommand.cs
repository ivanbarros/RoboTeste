using MediatR;

namespace Robo.Infra.Commands.Braco
{
    public class UpdateBracoCommand : IRequest<UpdateBracoCommandResponse>
    {
        public Domain.Entities.Braco Braco { get; set; }
    }
}
