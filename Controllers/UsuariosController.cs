using BlogdeNotas.Models;
using BlogdeNotas.Servicios;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogdeNotas.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public UsuariosController(UserManager<Usuario> userManager,SignInManager<Usuario> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Registro(RegistroViewModel modelo)
        {

            if (!ModelState.IsValid)
            {
                return  View(modelo);
            }

            var usuario = new Usuario()
            {
                Email = modelo.Email
                ,Nombre = modelo.Nombre
            };

            var resultado  = await userManager.CreateAsync(usuario,modelo.Password);

            if (resultado.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: false);
            return RedirectToAction("Index", "Notas");

            }
            else
            {
                foreach (var item in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }

                return View(modelo);
            }


        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {

            

            return View() ;
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var r = await signInManager.PasswordSignInAsync(model.Email,
                model.Password,model.Recuerdame,lockoutOnFailure:false);



            if (r.Succeeded)
            {
                return RedirectToAction("Index", "Notas");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult>Logout(){
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index","Notas");
        }
    }
}
