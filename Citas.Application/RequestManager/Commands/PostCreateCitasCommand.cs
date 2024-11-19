using Citas.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Commands
{
    public class PostCreateCitasCommand : IRequest<IActionResult>
    {
        public PostCreateCitasRequest PostCreateCitasRequest { get; set; }

    }
}
