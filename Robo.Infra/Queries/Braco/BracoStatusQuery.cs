using MediatR;

namespace Robo.Infra.Queries.Braco
{
    public class BracoStatusQuery : IRequest<BracoStatusResponse>
    {
       public string braco {  get; set; }
    }
}
