using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Autores.Commands.PostAutor
{
    public class PostAutorCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
