using BrowserTravelAplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Editorial.Queries.GetEditorial
{
    public class GetEditorialQuery : IRequest<List<EditorialVm>>
    {
        public GetEditorialQuery(int? Id)
        {
            id = Id;
        }
        public int? id { get; set; }
    }
}
