using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBrowserTravel.Models;
using WebBrowserTravel.Services;

namespace WebBrowserTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IService _servicioApi;

        #region Creacion de vistas
        public HomeController(ILogger<HomeController> logger, IService servicioApi)
        {
            _logger = logger;
            _servicioApi = servicioApi;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LibroAdd(int? Id)
        {
            List<Editorial> listaEditorial = await _servicioApi.GetEditorial(0);
            ViewBag.ListaEditorial = new SelectList(listaEditorial, "Id", "Nombre");
            return View();
        }
        public async Task<IActionResult> LibroUp(int? Id)
        {

            List<Libro> listaLibro = await _servicioApi.GetLibro(Id);
            Libro data = new Libro
            {
                Id = listaLibro.FirstOrDefault().Id,
                editorialId = listaLibro.FirstOrDefault().editorialId,
                titulo = listaLibro.FirstOrDefault().titulo,
                sinopsis = listaLibro.FirstOrDefault().sinopsis,
                nPaginas = listaLibro.FirstOrDefault().nPaginas 
                
            };
            List<Editorial> listaEditorial = await _servicioApi.GetEditorial(0);
            ViewBag.ListaEditorial = new SelectList(listaEditorial, "Id", "Nombre");

            return View(data);
        }
        public async Task<IActionResult> EditorialAdd(int? Id)
        {
            return View();
        }
        public async Task<IActionResult> EditorialUp(int? Id)
        {
            List<Editorial> lista = await _servicioApi.GetEditorial(Id);
            Editorial data = new Editorial
            {
                Id = lista.FirstOrDefault().Id,
                Nombre = lista.FirstOrDefault().Nombre,
                Sede = lista.FirstOrDefault().Sede

            };
            return View(data);
        }
        public async Task<IActionResult> AutorAdd()
        {

            return View();
        }
        public async Task<IActionResult> AutorUp(int? Id)
        {
            List<Autor> lista = await _servicioApi.GetAutor(Id);
            Autor data = new Autor
            {
                Id = lista.FirstOrDefault().Id,
                Nombre = lista.FirstOrDefault().Nombre,
                Apellido = lista.FirstOrDefault().Apellido

            };
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AutorList(Autor obj)
        {
            List<Autor> lista = await _servicioApi.GetAutor(obj.Id);
            return View(lista);

        }
        [HttpGet]
        public async Task<IActionResult> EditorialList(Editorial obj)
        {
            List<Editorial> lista = await _servicioApi.GetEditorial(obj.Id);
            return View(lista);

        }
        [HttpGet]
        public async Task<IActionResult> LibroList(Libro obj)
        {
            List<Libro> lista = await _servicioApi.GetLibro(obj.Id);
            return View(lista);

        }
        #endregion

        #region Insercion de datos

        [HttpPost]
        public async Task<IActionResult> AddAutor(Autor obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.AddAutor(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("AutorList");
            else
                //return NoContent();
                return RedirectToAction("AutorAdd");

        }
        [HttpPost]
        public async Task<IActionResult> AddEditorial(Editorial obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.AddEditorial(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EditorialList");
            else
                //return NoContent();
                return RedirectToAction("EditorialAdd");

        }
        [HttpPost]
        public async Task<IActionResult> AddLibro(Libro obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.AddLibro(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("LibroList");
            else
                //return NoContent();
                return RedirectToAction("LibroAdd");

        }
        #endregion

        #region Actualizacion de datos

        [HttpPost]
        public async Task<IActionResult> UpAutor(Autor obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.UpAutor(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("AutorList");
            else
                //return NoContent();
                return RedirectToAction("AutorUp");

        }
        [HttpPost]
        public async Task<IActionResult> UpEditorial(Editorial obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.UpEditorial(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("EditorialList");
            else
                //return NoContent();
                return RedirectToAction("EditorialUp");

        }
        [HttpPost]
        public async Task<IActionResult> UpLibro(Libro obj)
        {

            bool respuesta;

            if (obj != null)
            {
                respuesta = await _servicioApi.UpLibro(obj);
            }
            else
            {
                respuesta = false;
            }


            if (respuesta)
                return RedirectToAction("LibroList");
            else
                //return NoContent();
                return RedirectToAction("LibroUp");

        }
        #endregion
    }
}
