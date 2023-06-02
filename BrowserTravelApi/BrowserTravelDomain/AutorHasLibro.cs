using BrowserTravelDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelDomain
{
    public class AutorHasLibro : Entity
    {
        public int autorId { get; set; }
        [ForeignKey("autorId")]
        public Autors Autor { get; set; }
        public int libroId { get; set; }
        [ForeignKey("libroId")]
        public Libros Libro { get; set; }
    }
}
