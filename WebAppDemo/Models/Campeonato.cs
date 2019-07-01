using System.Collections.Generic;
using System.Linq;

namespace WebAppDemo.Models
{
    public class Campeonato
    {
        public List<Filme> Filmes { get; set; }
        public List<Confronto> Confrontos { get; set; }
        public Filme FilmeCampeao { get; set; }
        public Filme FilmeViceCampeao { get; set; }

        public bool ResolverFase()
        {
            List<Filme> FilmesClassificados = new List<Filme>();
            foreach (Confronto confronto in Confrontos)
            {
                if (confronto.Resolver())
                {
                    if (Confrontos.ToList().Count == 1)
                    {
                        FilmeCampeao = confronto.FilmeVencedor;
                        FilmeViceCampeao = confronto.FilmePerdedor;
                    }
                    else
                    {
                        FilmesClassificados.Add(confronto.FilmeVencedor);
                    }
                }
            }
            Filmes = FilmesClassificados;
            return true;
        }
    }
}
