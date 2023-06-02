using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using WebBrowserTravel.Models;

namespace WebBrowserTravel.Services
{
    public interface IService
    {
        Task<List<Autor>> GetAutor(int? Id);
        Task<List<Editorial>> GetEditorial(int? Id);
        Task<List<Libro>> GetLibro(int? Id);
        Task<bool> AddAutor(Autor obj);
        Task<bool> AddEditorial(Editorial obj);
        Task<bool> AddLibro(Libro obj);
        Task<bool> UpAutor(Autor obj);
        Task<bool> UpEditorial(Editorial obj);
        Task<bool> UpLibro(Libro obj);

    }
}
