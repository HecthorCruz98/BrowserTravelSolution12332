using BrowserTravelDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserTravelAplication.Models
{
    public class LibroVm
    {
        public int Id { get; set; }
        public int editorialId { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string nPaginas { get; set; }
    }
}
