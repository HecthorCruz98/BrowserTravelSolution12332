using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Libro.Commands.PutLibro
{
    public class PutLibroCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int editorialId { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string nPaginas { get; set; }
    }
}
