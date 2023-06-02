using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Editorial.Commands.PostEditorial
{
    public class PostEditorialCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Sede { get; set; }
    }
}
