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

namespace BrowserTravelAplication.Features.Autores.Commands.PostAutor
{
    public class PostAutorCommandHandler : IRequestHandler<PostAutorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostAutorCommandHandler> _logger;

        public PostAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostAutorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(PostAutorCommand request, CancellationToken cancellationToken)
        {
            int resp = 0;
            if (request != null)
            {
                var Entity = _mapper.Map<Autors>(request);
                var EntityAdd = await _unitOfWork.Repository<Autors>().AddAsync(Entity);
                _logger.LogInformation($"El Autor fue creado con el id {EntityAdd.Id}");
                
                return resp = 1;
            }
            else
            {
                return resp = 0;
            }
        }
    }
}
