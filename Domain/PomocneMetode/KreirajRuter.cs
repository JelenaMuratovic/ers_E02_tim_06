using Domain.Models;

namespace Domain.PomocneMetode
{
    public class KreirajRuter
    {
        public Ruter KreiranjeRutera()
        {
            return new Ruter(NasumicnoGenerisanjeRutera.GenerisiSerijskiBrojProizvodjaca(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicnuMaxBrzinaPrenosaPodataka(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicanBrojLANPrikljucka(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicnuVrstuRutera());
        }
    }
}
