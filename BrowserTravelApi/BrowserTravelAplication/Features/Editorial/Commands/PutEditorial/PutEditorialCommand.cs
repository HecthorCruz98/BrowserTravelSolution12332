using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Editorial.Commands.PutEditorial
{
    public class PutEditorialCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sede { get; set; }
    }
}
