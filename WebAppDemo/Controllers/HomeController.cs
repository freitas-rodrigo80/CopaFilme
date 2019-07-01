using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppDemo.HttpClients;
using WebAppDemo.Models;

namespace WebAppDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            FilmeApiClient film = new FilmeApiClient();
            var filmes = film.GetFilmeAsync();
            return View(filmes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ResultadoFinal(string campeao, string vicecampeao)
        {
            ViewBag.Campeao = campeao;
            ViewBag.ViceCampeao = vicecampeao;

            return View();
        }
    }
}
