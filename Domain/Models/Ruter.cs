using Domain.Enums;

namespace Domain.Models
{
    public class Ruter
    {
        public string SerijskiBrojProizvodjaca { get; set; } = "";
        public int MaxBrzinaPrenosaPodataka { get; set; }
        public int BrojLANPrikljucka { get; set; }
        public VrstaRutera VrstaRutera { get; set; }

        public Ruter(string serijskiBrojProizvodjaca, int maxBrzinaPrenosaPodataka, int brojLANPrikljucka, VrstaRutera vrstaRutera)
        {
            SerijskiBrojProizvodjaca = serijskiBrojProizvodjaca;
            MaxBrzinaPrenosaPodataka = maxBrzinaPrenosaPodataka;
            BrojLANPrikljucka = brojLANPrikljucka;
            VrstaRutera = vrstaRutera;
        }
    }

}
