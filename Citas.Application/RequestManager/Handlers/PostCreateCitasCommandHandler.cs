using AutoMapper;
using Citas.Application.Feature;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Services.Interfaces.Citas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Handlers
{
    public class PostCreateCitasCommandHandler : IRequestHandler<PostCreateCitasCommand, IActionResult>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public PostCreateCitasCommandHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            this._citaRepository = citaRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Handle(PostCreateCitasCommand request, CancellationToken cancellationToken)
        {
            if (this._citaRepository.GetByExistCitas(request.PostCreateCitasRequest.IdPaciente, request.PostCreateCitasRequest.IdMedico) == null)
            {
                var Entitymapper = _mapper.Map<Domain.Entities.Citas>(request.PostCreateCitasRequest);
                Entitymapper.IdCita = Guid.NewGuid();
                this._citaRepository.Add(Entitymapper);
                this._citaRepository.Save();
                return ResponseApiService.Response(StatusCodes.Status201Created, Entitymapper);
            }
            else
            {
                return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Cita Ya Registrada");
            }
        }
    }
}
