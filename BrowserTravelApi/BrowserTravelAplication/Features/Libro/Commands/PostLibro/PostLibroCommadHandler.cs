using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelAplication.Features.Autores.Commands.PostAutor;
using BrowserTravelDomain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Libro.Commands.PostLibro
{
    public class PostLibroCommadHandler : IRequestHandler<PostLibroCommad, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostLibroCommadHandler> _logger;

        public PostLibroCommadHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostLibroCommadHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(PostLibroCommad request, CancellationToken cancellationToken)
        {
            int resp = 0;
            if (request != null)
            {
                var Entity = _mapper.Map<Libros>(request);
                var EntityAdd = await _unitOfWork.Repository<Libros>().AddAsync(Entity);
                _logger.LogInformation($"El libro fue creado con el id {EntityAdd.Id}");

                return resp = 1;
            }
            else
            {
                return resp = 0;
            }
        }
    }
}
