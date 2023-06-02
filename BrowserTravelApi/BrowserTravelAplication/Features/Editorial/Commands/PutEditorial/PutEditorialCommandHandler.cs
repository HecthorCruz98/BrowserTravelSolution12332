using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelAplication.Features.Autores.Commands.PutAutor;
using BrowserTravelDomain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Editorial.Commands.PutEditorial
{
    public class PutEditorialCommandHandler : IRequestHandler<PutEditorialCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PutEditorialCommandHandler> _logger;
        public PutEditorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PutEditorialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(PutEditorialCommand request, CancellationToken cancellationToken)
        {
            var verifyData = await _unitOfWork.Repository<Editorials>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            int resp = 0;

            if (verifyData != null)
            {
                verifyData.Nombre = request.Nombre;
                verifyData.Sede = request.Sede;

                await _unitOfWork.Repository<Editorials>().UpdateAsync(verifyData);

                _logger.LogInformation($"El Editorial con el id {verifyData.Id} fue actualizado correctamente ");


                return resp = 1;

            }
            else
            {
                return resp = 0;
            }
        }
    }
}
