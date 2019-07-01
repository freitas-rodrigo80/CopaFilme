using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppDemo.Controllers
{
    [Route("Campeonato")]
    public class CampeonatoController : Controller
    {
        [HttpPost("Gerar")]
        public ActionResult Gerar([FromBody]List<Filme> listFilmes)
        {
                return Json(Campeonato(listFilmes));
        }

        public Campeonato Campeonato(List<Filme> Filmes)
        {
            Campeonato campeonato = new Campeonato { Filmes = Filmes.OrderBy(f => f.Titulo).ToList() };
            campeonato.Confrontos = ConfrontosIniciais(campeonato.Filmes.ToList());
            Campeao(campeonato);
            return campeonato;
        }

        public List<Confronto> ConfrontosIniciais(List<Filme> Filmes)
        {
            var ListaConfrontos = new List<Confronto>();
            while (Filmes.Count > 0)
            {
                ListaConfrontos.Add(new Confronto(Filmes[0], Filmes[Filmes.Count - 1]));
                Filmes.RemoveAt(Filmes.Count - 1);
                Filmes.RemoveAt(0);
            }
            return ListaConfrontos;
        }

        private void Campeao(Campeonato campeonato)
        {
            while (campeonato.FilmeCampeao == null || string.IsNullOrEmpty(campeonato.FilmeCampeao.Id))
            {
                if (campeonato.ResolverFase())
                {
                    campeonato.Confrontos = ConfrontoFinal(campeonato.Filmes.ToList());
                }
                else
                {
                    break;
                }
            }
        }

        public List<Confronto> ConfrontoFinal(List<Filme> Filmes)
        {
            List<Confronto> ListaConfrontos = new List<Confronto>();
            while (Filmes.Count > 0)
            {
                ListaConfrontos.Add(new Confronto(Filmes[0], Filmes[1]));
                Filmes.RemoveAt(1);
                Filmes.RemoveAt(0);
            }
            return ListaConfrontos;
        }
    }
}
