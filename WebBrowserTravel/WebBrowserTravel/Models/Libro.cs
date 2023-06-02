using System.ComponentModel.DataAnnotations.Schema;

namespace WebBrowserTravel.Models
{
    public class Libro
    {
        /// <summary>
        /// Clase que hace refencia a los libros registrados en el sistema
        /// </summary>
        public int Id { get; set; }
        public int editorialId { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string nPaginas { get; set; }
    }
}
