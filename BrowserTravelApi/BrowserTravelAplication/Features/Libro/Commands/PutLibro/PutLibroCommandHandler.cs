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

namespace BrowserTravelAplication.Features.Libro.Commands.PutLibro
{
    public class PutLibroCommandHandler : IRequestHandler<PutLibroCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PutLibroCommandHandler> _logger;
        public PutLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PutLibroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(PutLibroCommand request, CancellationToken cancellationToken)
        {
            var verifyData = await _unitOfWork.Repository<Libros>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            int resp = 0;

            if (verifyData != null)
            {
                verifyData.titulo = request.titulo;
                verifyData.editorialId = request.editorialId;
                verifyData.nPaginas = request.nPaginas;
                verifyData.sinopsis = request.sinopsis;

                await _unitOfWork.Repository<Libros>().UpdateAsync(verifyData);

                _logger.LogInformation($"El libro con el id {verifyData.Id} fue actualizado correctamente ");


                return resp = 1;

            }
            else
            {
                return resp = 0;
            }
        }
    }
}
