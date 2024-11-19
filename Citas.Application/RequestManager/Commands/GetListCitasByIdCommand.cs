using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Commands
{
    public class GetListCitasByIdCommand : IRequest<IActionResult>
    {
        public Guid IdCita { get; set; }

    }
}
