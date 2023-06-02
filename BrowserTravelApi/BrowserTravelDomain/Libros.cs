using BrowserTravelDomain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelDomain
{
    public class Libros : Entity
    {
        public int editorialId { get; set; }
        [ForeignKey("editorialId")]
        public Editorials Editorial { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string nPaginas { get; set; }
    }
}
