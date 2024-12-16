using Domain.Enums;
using Domain.Models;
using Domain.Services;
using Prezentacija.GenerisanjePaketa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.KreiranjeRacunara
{
    public class KreirajRacunar : IKreirajRacunar
    {
        Racunar IKreirajRacunar.KreirajRacunar()
        {
            return new Racunar(NasumicnoGenerisanjeRacunara.GenerisiSerijskiBroj(),
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanKapacitetRadneMemorije(), 
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanKapacitetSkladisneMemorije(), 
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanTipSkladisneMemorije(), 
                                NasumicnoGenerisanjeRacunara.GenerisiLokalnuIPAdresu());
        }
    }
}
