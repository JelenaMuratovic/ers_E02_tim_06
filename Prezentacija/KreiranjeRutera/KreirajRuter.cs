using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Prezentacija.GenerisanjeEntiteta;

namespace Prezentacija.KreiranjeRutera
{
    public class KreirajRuter : IKreiranjeRuteraServis
    {
        Ruter IKreiranjeRuteraServis.KreirajRuter()
        {
            return new Ruter(NasumicnoGenerisanjeRutera.GenerisiSerijskiBrojProizvodjaca(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicnuMaxBrzinaPrenosaPodataka(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicanBrojLANPrikljucka(),
                             NasumicnoGenerisanjeRutera.GenerisiNasumicnuVrstuRutera());
        }
    }
}
