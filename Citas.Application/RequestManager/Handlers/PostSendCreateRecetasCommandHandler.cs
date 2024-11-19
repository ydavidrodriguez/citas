using AutoMapper;
using Citas.Application.Feature;
using Citas.Application.RequestManager.Commands;
using Citas.Domain.Dto;
using Citas.Domain.Services.Interfaces.Citas;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Citas.Application.RequestManager.Handlers
{
    public class PostSendCreateRecetasCommandHandler : IRequestHandler<PostSendCreateRecetasCommand, IActionResult>
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public PostSendCreateRecetasCommandHandler(ICitaRepository citaRepository, IMapper mapper)
        {
            this._citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(PostSendCreateRecetasCommand request, CancellationToken cancellationToken)
        {


            ConnectionFactory factory = new ConnectionFactory();
            // "guest"/"guest" by default, limited to localhost connections
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.HostName = "localhost";



            IConnection conn = await factory.CreateConnectionAsync();
            IChannel channel = await conn.CreateChannelAsync();


            // Declarar una cola
            string queueName = "mi_cola_v7";
            channel.QueueDeclareAsync(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            //Crear El Objeto 

            CreateRecetasRequest createRecetasRequest = new CreateRecetasRequest
            {
                Descripcion = request.createRecetasRequest.Descripcion,
                IdEstado = request.createRecetasRequest.IdEstado,
                IdPaciente = request.createRecetasRequest.IdPaciente,

            };

            // Crear el mensaje a enviar
            string jsonstring = JsonSerializer.Serialize(createRecetasRequest);
            byte[] body = Encoding.UTF8.GetBytes(jsonstring);

            // Enviar el mensaje a la cola

            channel.BasicPublishAsync(exchange: "",
                                 routingKey: queueName,
                                 true,
                                 body: body);


            return ResponseApiService.Response(StatusCodes.Status202Accepted, null, "Receta Enviada");
        }
    }
}
