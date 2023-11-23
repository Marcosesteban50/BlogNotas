using BlogdeNotas.Models;
using BlogdeNotas.Servicios;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BlogdeNotas.Controllers
{
    public class NotasController : Controller
    {
        private readonly IRepositorioNotas repositorioNotas;
        private readonly IServicioUsuarios servicioUsuarios;

        public NotasController(IRepositorioNotas repositorioNotas,
            IServicioUsuarios servicioUsuarios)
        {
            this.repositorioNotas = repositorioNotas;
            this.servicioUsuarios = servicioUsuarios;
        }
        
        public async Task<IActionResult> Index()
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var Notas = await repositorioNotas.Obtener(usuarioId);
            return View(Notas);
        }




        public IActionResult Crear()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Notas notas)
        {

            if (!ModelState.IsValid)
            {
                return View(notas);
            }




            notas.UsuarioId = servicioUsuarios.ObtenerUsuarioId();




            var existe = await repositorioNotas.Existe(notas.Nombre,
                notas.UsuarioId);

            if (existe)
            {
                ModelState.AddModelError(nameof(notas.Nombre), $"{notas.Nombre} Ya Existe.");
                return View(notas);
            }
            await repositorioNotas.Crear(notas);


            return RedirectToAction("Index");
        }




        
        public async Task<IActionResult> VistaNotas(Notas notas)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var notaExiste = await repositorioNotas.ObtenerporId(notas.Id, usuarioId);

            if (notaExiste is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");
            }

          


            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> VistaNotas(int id)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var notas = await repositorioNotas.ObtenerporId(id, usuarioId);

            if (notas is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");
            }

            return View(notas);
        }




        [HttpPost]
        public async Task<IActionResult> Editar(Notas notas)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var notaExiste = await repositorioNotas.ObtenerporId(notas.Id, usuarioId);

            if (notaExiste is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");
            }

            await repositorioNotas.Actualizar(notas);


            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var notas = await repositorioNotas.ObtenerporId(id, usuarioId);

            if (notas is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");
            }

            return View(notas);
        }



        public IActionResult NoEncontrado()
        {
            return View();
        }


        public async Task<IActionResult> Borrar(int id)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var nota = await repositorioNotas.ObtenerporId(id, usuarioId);

            if (nota is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");

            }

            return View(nota);
        }


        [HttpPost]
        public async Task<IActionResult> BorrarNota(int id)
        {
            var usuarioId = servicioUsuarios.ObtenerUsuarioId();
            var nota = await repositorioNotas.ObtenerporId(id, usuarioId);

            if (nota is null)
            {
                return RedirectToAction("NoEncontrado", "Notas");

            }
            await repositorioNotas.Borrar(id);

            return RedirectToAction("Index");
        }
    }
}
