﻿using BrowserTravelAplication.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Features.Autores.Queries.GetAutor
{
    public class GetAutorQuery : IRequest<List<AutorVm>>
    {
        public GetAutorQuery(int? Id)
        {
            id = Id;
        }
        public int? id { get; set; }
    }
}
