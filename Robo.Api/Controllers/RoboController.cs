using MediatR;
using Microsoft.AspNetCore.Mvc;
using Robo.Infra.Commands.Braco;
using Robo.Infra.Queries.Braco;
using Swashbuckle.AspNetCore.Annotations;

namespace Robo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboController : ControllerBase
    {
        [HttpGet]
        [Route("bracodireitostatus")]
        [SwaggerOperation(
             Summary = "Seleciona o status do braço direito do robo"
         )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Get([FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new BracoStatusQuery());
            return Ok(result);
        }
        
        [HttpPost]
        [Route("bracostatus")]
        [SwaggerOperation(
             Summary = "Insere o status do braço  do robo"
         )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromServices] IMediator mediator, [FromBody] BracoCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        
        
        [HttpPut]
        [Route("bracostatus")]
        [SwaggerOperation(
             Summary = "Atualiza o status do braço  do robo"
         )]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Put([FromServices] IMediator mediator, [FromBody] UpdateBracoCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

    }
}
