using AutoMapper;
using MediatR;
using Robo.Domain.Enums;
using Robo.Domain.Interfaces.Services;
using Robo.Infra.Commands.Braco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo.Infra.Handlers
{
    internal class BracoCommandHandler : IRequestHandler<BracoCommand, BracoCommandResponse>
    {
        private readonly IBracoStateService _stateService;
        private readonly IMapper _mapper;

        public BracoCommandHandler(IBracoStateService stateService, IMapper mapper)
        {
            _stateService = stateService;
            _mapper = mapper;
        }

        public async Task<BracoCommandResponse> Handle(BracoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new BracoCommandResponse();
                var cotovelo = await _stateService.MoveCotovelo(request.Cotovelo.Cotovelos,request.escolhaBraco.ToString());
                var pulso = await _stateService.MovePulso(request.Pulso.Pulsos.ToString(), request.escolhaBraco.ToString());
                if (request.escolhaBraco == EscolhaBracoEnum.esquerdo)
                {
                    var bracos = _stateService.MoveBraco(cotovelo, pulso, "esquerdo");
                }
                else
                {
                    var bracos = _stateService.MoveBraco(cotovelo, pulso, "direito");
                }


                response.RotacaoCotoveloResult = cotovelo.ToString();
                response.StatusPulsoResult = pulso.ToString();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
