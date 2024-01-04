using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Robo.Domain.Interfaces.Services;
using Robo.Infra.Queries.Braco;

namespace Robo.Infra.Handlers
{
    public class BracoDireitoStatusQueryHandler : IRequestHandler<BracoStatusQuery, BracoStatusResponse>
    {
        private readonly IBracoStateService _stateService;
        private readonly IMediator _mediator;
        private readonly ILogger<BracoDireitoStatusQueryHandler> _logger;
        private readonly IMapper _mapper;

        public BracoDireitoStatusQueryHandler(IBracoStateService stateService, IMediator mediator, ILogger<BracoDireitoStatusQueryHandler> logger, IMapper mapper)
        {
            _stateService = stateService;
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BracoStatusResponse> Handle(BracoStatusQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _stateService.CheckMoveBraco(request.braco);

            var response = _mapper.Map<BracoStatusResponse>(result);
            return response;
        }
    }
}
