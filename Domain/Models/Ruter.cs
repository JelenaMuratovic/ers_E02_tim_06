using Domain.Enums;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ruter
    {
        public string SerijskiBrojProizvodjaca { get; set; } = "";
        public int MaxBrzinaPrenosaPodataka { get; set; }
        public int BrojLANPrikljucka { get; set; }
        public VrstaRutera VrstaRutera { get; set; }

        public IPaketRepozitorijum paketi_rutera = new PaketRepozitorijum();

        public Ruter(string serijskiBrojProizvodjaca, int maxBrzinaPrenosaPodataka, int brojLANPrikljucka, VrstaRutera vrstaRutera)
        {
            SerijskiBrojProizvodjaca = serijskiBrojProizvodjaca;
            MaxBrzinaPrenosaPodataka = maxBrzinaPrenosaPodataka;
            BrojLANPrikljucka = brojLANPrikljucka;
            VrstaRutera = vrstaRutera;
        }
    }
    
}
