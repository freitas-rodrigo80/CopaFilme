
namespace WebAppDemo.Models
{
    public class Confronto
    {
        public Filme Filme1 { get; set; }
        public Filme Filme2 { get; set; }
        public Filme FilmeVencedor { get; set; }
        public Filme FilmePerdedor { get; set; }

        public Confronto(Filme Filme1, Filme Filme2)
        {
            this.Filme1 = Filme1;
            this.Filme2 = Filme2;
            this.FilmeVencedor = null;
        }

        public bool Resolver()
        {
            if (Filme1.Nota > Filme2.Nota)
            {
                FilmeVencedor = Filme1;
                FilmePerdedor = Filme2;
            }
            else if (Filme1.Nota < Filme2.Nota)
            {
                FilmeVencedor = Filme2;
                FilmePerdedor = Filme1;
            }
            else
                FilmeVencedor = DesempateOrdemAlfabetica();

            return true;
        }

        public Filme DesempateOrdemAlfabetica(int index = 0)
        {
            if (Filme1.Titulo[index] < Filme2.Titulo[index])
                return Filme1;
            else if (Filme1.Titulo[index] > Filme2.Titulo[index])
                return Filme2;
            else
            {
                index++;
                if (Filme1.Titulo.Length > index && Filme2.Titulo.Length > index)
                    return DesempateOrdemAlfabetica(index);
                else
                    return Filme1;
            }
        }
    }
}
