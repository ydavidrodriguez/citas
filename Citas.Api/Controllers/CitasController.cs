using Citas.Application.ExceptionManager;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CitasController : ControllerBase
    {
        #region
        private readonly IMediator _mediator;
        #endregion

        public CitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostCreateCitas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        public async Task<IActionResult> PostCreateCitas([FromBody] PostCreateCitasRequest postCreateCitasRequest)
        {
            return await _mediator.Send(new PostCreateCitasCommand
            {
                PostCreateCitasRequest = postCreateCitasRequest
            });

        }
        [HttpGet("getCitaById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        public async Task<IActionResult> getCitaById([FromQuery] Guid idCita)
        {
            return await _mediator.Send(new GetListCitasByIdCommand
            {
                IdCita = idCita
            });
        }
        [HttpPut("PutUpdateCita")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        public async Task<IActionResult> PutUpdatePersona([FromBody] PutUpdateCitasRequest putUpdateCitasRequest)
        {
            return await _mediator.Send(new PutUpdateCitasCommand
            {
                putUpdateCitasRequest = putUpdateCitasRequest
            });
        }
        [HttpPost("PostSendCreateRecetas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ExceptionManager))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ExceptionManager))]
        public async Task<IActionResult> PostSendCreateRecetas([FromBody] CreateRecetasRequest createRecetasRequest)
        {
            return await _mediator.Send(new PostSendCreateRecetasCommand
            {
              createRecetasRequest = createRecetasRequest

            });

        }

    }
}