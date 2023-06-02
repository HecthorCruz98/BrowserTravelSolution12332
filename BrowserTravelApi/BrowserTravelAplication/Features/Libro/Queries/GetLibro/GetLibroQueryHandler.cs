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

namespace BrowserTravelAplication.Features.Libro.Queries.GetLibro
{
    public class GetLibroQueryHandler : IRequestHandler<GetLibroQuery, List<LibroVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetLibroQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLibroQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<GetLibroQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<LibroVm>> Handle(GetLibroQuery request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                var Entity = await _unitOfWork.Repository<Libros>().GetAsync(x => x.Id == request.id);
                var EntityVm = _mapper.Map<List<LibroVm>>(Entity);

                return EntityVm;

            }
            else
            {
                var Entity = await _unitOfWork.Repository<Libros>().GetAllAsync();
                var EntityVm = _mapper.Map<List<LibroVm>>(Entity);

                return EntityVm;

            }
        }
    }
}
