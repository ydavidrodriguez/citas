using Citas.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Commands
{
    public class PutUpdateCitasCommand : IRequest<IActionResult>
    {
        public PutUpdateCitasRequest putUpdateCitasRequest { get; set; }
    }
}
