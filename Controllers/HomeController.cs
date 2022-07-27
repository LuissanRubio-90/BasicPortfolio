using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IEmailService emailService;

        public HomeController(ILogger<HomeController> logger, 
                                      IRepositorioProyectos repositorioProyectos,
                                      IEmailService emailService
                                      )

        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            
            _logger.LogTrace("Este es un mensaje de trace");
            _logger.LogDebug("Este es un mensaje de debug");
            _logger.LogInformation("Este es un mensaje de information");
            _logger.LogWarning("Este es un mensaje de warning");
            _logger.LogError("Este es un mensaje de error");
            _logger.LogCritical("Este es un mensaje de critial");

            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndex() 
            { 
                Proyectos = proyectos,
            };

            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Projects()
        {
            var proyectos = repositorioProyectos?.ObtenerProyectos();
            return View(proyectos);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(Contact contact)
        {
            await emailService.Enviar(contact);
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}