using BrowserTravelAplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Libro.Queries.GetLibro
{
    public class GetLibroQuery : IRequest<List<LibroVm>>
    {
        public GetLibroQuery(int? Id)
        {
            id = Id;
        }
        public int? id { get; set; }
    }
}
