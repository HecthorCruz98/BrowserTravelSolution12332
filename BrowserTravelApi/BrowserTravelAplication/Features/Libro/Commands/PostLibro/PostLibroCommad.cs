using BrowserTravelDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Libro.Commands.PostLibro
{
    public class PostLibroCommad : IRequest<int>
    {
        public int editorialId { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string nPaginas { get; set; }
    }
}
