using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelDomain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Autores.Commands.PutAutor
{
    public class PutAutorCommandHandler : IRequestHandler<PutAutorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PutAutorCommandHandler> _logger;
        public PutAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PutAutorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(PutAutorCommand request, CancellationToken cancellationToken)
        {
            var verifyData = await _unitOfWork.Repository<Autors>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            int resp = 0;

            if (verifyData != null)
            {
                verifyData.Nombre = request.Nombre;
                verifyData.Apellido = request.Apellido;

                await _unitOfWork.Repository<Autors>().UpdateAsync(verifyData);

                _logger.LogInformation($"El autor con el id {verifyData.Id} fue actualizado correctamente ");


                return resp = 1;

            }
            else
            {
               return resp = 0;
            }
        }
    }
}
