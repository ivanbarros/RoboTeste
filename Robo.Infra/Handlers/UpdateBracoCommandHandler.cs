using AutoMapper;
using MediatR;
using Robo.Domain.Interfaces.Services;
using Robo.Infra.Commands.Braco;
using Robo.Infra.Extension;

namespace Robo.Infra.Handlers
{
    public class UpdateBracoCommandHandler : IRequestHandler<UpdateBracoCommand, UpdateBracoCommandResponse>
    {
        private readonly IBracoStateService _stateService;
        private readonly IMapper _mapper;

        public UpdateBracoCommandHandler(IBracoStateService stateService, IMapper mapper)
        {
            _stateService = stateService;
            _mapper = mapper;
        }

        public async Task<UpdateBracoCommandResponse> Handle(UpdateBracoCommand request, CancellationToken cancellationToken)
        {

            var response = new UpdateBracoCommandResponse();
            var rotacao = RoboRotacaoExtension.MoveCotoveloParaProximoEstado(request.Braco.Cotovelo.Cotovelos);
            foreach (var item in rotacao)
            {
                if (item.Key.Equals(false))
                {
                    response.Result = $"Não foi possivel mover status do cotovelo do robo, status atual: {item.Value}";
                    return response;
                }
                await _stateService.UpdateMoveCotovelo(item.Value.ToString(), request.Braco.Lado);
                
                var checkCotovelo =await _stateService.CheckMoveBraco(request.Braco.Lado);
                
                var status = RoboRotacaoExtension.MovimentoPulsoValido(checkCotovelo.Cotovelo.Cotovelos,request.Braco.Pulso.Pulsos);
                
                if (item.Key.Equals(false))
                {
                    response.Result = $"Não foi possivel mover status do pulso do robo, status atual: {item.Value}";
                    return response;
                }
            }

            var checkbraco = await _stateService.CheckMoveBraco(request.Braco.Lado);

            await _stateService.MovePulso(request.Braco.Pulso.Pulsos.ToString(), request.Braco.Lado);


            throw new NotImplementedException();
        }
    }
}
