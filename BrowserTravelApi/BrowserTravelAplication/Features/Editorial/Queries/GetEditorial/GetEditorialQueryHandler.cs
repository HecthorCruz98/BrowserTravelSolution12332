using AutoMapper;
using BrowserTravelAplication.Contracts.Persistence;
using BrowserTravelAplication.Features.Autores.Queries.GetAutor;
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

namespace BrowserTravelAplication.Features.Editorial.Queries.GetEditorial
{
    public class GetEditorialQueryHandler : IRequestHandler<GetEditorialQuery, List<EditorialVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetEditorialQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetEditorialQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetEditorialQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<EditorialVm>> Handle(GetEditorialQuery request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                var Entity = await _unitOfWork.Repository<Editorials>().GetAsync(x => x.Id == request.id);
                var EntityVm = _mapper.Map<List<EditorialVm>>(Entity);

                return EntityVm;

            }
            else
            {
                var Entity = await _unitOfWork.Repository<Editorials>().GetAllAsync();
                var EntityVm = _mapper.Map<List<EditorialVm>>(Entity);

                return EntityVm;

            }
        }
    }
}
