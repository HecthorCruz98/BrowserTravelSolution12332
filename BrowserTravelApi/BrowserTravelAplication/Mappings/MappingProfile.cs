using AutoMapper;
using BrowserTravelAplication.Features.Autores.Commands.PostAutor;
using BrowserTravelAplication.Features.Autores.Commands.PutAutor;
using BrowserTravelAplication.Features.Editorial.Commands.PostEditorial;
using BrowserTravelAplication.Features.Editorial.Commands.PutEditorial;
using BrowserTravelAplication.Features.Libro.Commands.PostLibro;
using BrowserTravelAplication.Features.Libro.Commands.PutLibro;
using BrowserTravelAplication.Models;
using BrowserTravelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<PostEditorialCommand, Editorials>();
            CreateMap<PutEditorialCommand, Editorials>();
            CreateMap<Editorials, EditorialVm>();

            CreateMap<PostAutorCommand, Autors>();
            CreateMap<PutAutorCommand, Autors>();
            CreateMap<Autors, AutorVm>();
             
            CreateMap<PostLibroCommad, Libros>();
            CreateMap<PutLibroCommand, Libros>();
            CreateMap<Libros, LibroVm>();

        }
    }
}
