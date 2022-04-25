using CadastroUsuarioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleSign.Models;
using System.Diagnostics;

namespace SimpleSign.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario user)
        {

            Repository ur = new();

            ur.Insert(user);
            ViewBag.Mensagem = "Usuário cadastrado com sucesso!";
            return View();
        }

        public IActionResult Listar()
        {

            Repository ur = new();

            List<Usuario> listagem = ur.Listar();

            return View(listagem);
        }



        [HttpPost]
        public IActionResult Login(Usuario u)
        {

            Repository ur = new();
            Usuario user = ur.Consulta(u);

            if (user != null)
            {

                ViewBag.Mensagem = "Você está logado!";
                HttpContext.Session.SetInt32("id", user.id);
                HttpContext.Session.SetString("nome", user.nome);
                return Redirect("Cadastro");
            }

            else
            {

                ViewBag.Mensagem = "Falha no Login";
                return View();
            }
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}