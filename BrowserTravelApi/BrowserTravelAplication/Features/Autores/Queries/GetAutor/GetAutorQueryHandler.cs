using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelAplication.Models;
using BrowserTravelDomain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Autores.Queries.GetAutor
{
    public class GetAutorQueryHandler : IRequestHandler<GetAutorQuery, List<AutorVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAutorQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAutorQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetAutorQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<AutorVm>> Handle(GetAutorQuery request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                var Entity = await _unitOfWork.Repository<Autors>().GetAsync(x => x.Id == request.id);
                var EntityVm = _mapper.Map<List<AutorVm>>(Entity);

                return EntityVm;

            }
            else
            {
                var Entity = await _unitOfWork.Repository<Autors>().GetAllAsync();
                var EntityVm = _mapper.Map<List<AutorVm>>(Entity);

                return EntityVm;

            }

        }
    }
}
