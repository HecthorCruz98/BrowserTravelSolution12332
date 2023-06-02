using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelDomain;
using BrowserTravelAplication.Features.Autores.Commands.PostAutor;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Editorial.Commands.PostEditorial
{
    public class PostEditorialCommandHandler : IRequestHandler<PostEditorialCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostEditorialCommandHandler> _logger;

        public PostEditorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostEditorialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(PostEditorialCommand request, CancellationToken cancellationToken)
        {
            int resp = 0;
            if (request != null)
            {
                var Entity = _mapper.Map<Editorials>(request);
                var EntityAdd = await _unitOfWork.Repository<Editorials>().AddAsync(Entity);
                _logger.LogInformation($"El editorial fue creado con el id {EntityAdd.Id}");

                return resp = 1;
            }
            else
            {
                return resp = 0;
            }
        }
    }
}
