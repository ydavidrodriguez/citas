using Citas.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Commands
{
    public class PostSendCreateRecetasCommand : IRequest<IActionResult>
    {
        public  CreateRecetasRequest createRecetasRequest { get; set; }

    }
}
