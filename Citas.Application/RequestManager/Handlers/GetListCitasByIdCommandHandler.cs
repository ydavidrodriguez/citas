using AutoMapper;
using Citas.Application.Feature;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Services.Interfaces.Citas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Handlers
{
    public class GetListCitasByIdCommandHandler : IRequestHandler<GetListCitasByIdCommand, IActionResult>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public GetListCitasByIdCommandHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            this._citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetListCitasByIdCommand request, CancellationToken cancellationToken)
        {

            return ResponseApiService.Response(StatusCodes.Status201Created, _citaRepository.GetByIdCitas(request.IdCita));

        }

    }
}
