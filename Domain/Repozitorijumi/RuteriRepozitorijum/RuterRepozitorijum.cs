using Domain.Enums;
using Domain.Models;

namespace Domain.Repozitorijumi.RuteriRepozitorijum
{
    public class RuterRepozitorijum : IRuterRepozitorijum
    {
        private static List<Ruter> ruteri;

        static RuterRepozitorijum()
        {
            ruteri =
                [
                    new("223", 300, 89, VrstaRutera.OBICNI),
                    new("224", 500, 32, VrstaRutera.BEZICNI),
                    new("225", 200, 23, VrstaRutera.OBICNI),
                    new("226", 350, 12, VrstaRutera.BEZICNI)
                ];
        }
        public bool DodajRuter(Ruter ruter)
        {
            foreach (Ruter r in ruteri)
            {
                if (r.SerijskiBrojProizvodjaca.Equals(ruter.SerijskiBrojProizvodjaca))
                    return false;
            }
            ruteri.Add(ruter);
            return true;
        }
        public IEnumerable<Ruter> DobaviRutere()
        {
            return ruteri;
        }

        public override string? ToString()
        {
            string ruteri_ispis = "";
            foreach (Ruter r in ruteri)
            {
                ruteri_ispis += r.SerijskiBrojProizvodjaca + "\n";
            }
            return ruteri_ispis;
        }
    }
}
