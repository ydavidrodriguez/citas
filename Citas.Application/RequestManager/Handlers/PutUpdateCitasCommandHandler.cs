using AutoMapper;
using Citas.Application.Feature;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Services.Interfaces.Citas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Citas.Application.RequestManager.Handlers
{
    public class PutUpdateCitasCommandHandler : IRequestHandler<PutUpdateCitasCommand, IActionResult>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public PutUpdateCitasCommandHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            this._citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(PutUpdateCitasCommand request, CancellationToken cancellationToken)
        {

            Domain.Entities.Citas cita = _citaRepository.GetByIdCitas(request.putUpdateCitasRequest.IdCita);
            if (cita != null)
            {
                if (_citaRepository.GetByExistCitas(request.putUpdateCitasRequest.IdPaciente, request.putUpdateCitasRequest.IdMedico) == null)
                {
                    cita.IdMedico = request.putUpdateCitasRequest.IdMedico;
                    cita.IdPaciente = request.putUpdateCitasRequest.IdPaciente;
                    cita.FechaCita = request.putUpdateCitasRequest.FechaCita;
                    cita.EstadoId = request.putUpdateCitasRequest.EstadoId;

                    _citaRepository.Update(cita);
                    _citaRepository.Save();

                    return ResponseApiService.Response(StatusCodes.Status201Created, request.putUpdateCitasRequest);

                }
                else
                {
                    return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "la  cita  Ya Esta Registrada");
                }
            }
            else { return ResponseApiService.Response(StatusCodes.Status202Accepted, "la  cita Ya Esta Registrada"); }

        }
    }
}
