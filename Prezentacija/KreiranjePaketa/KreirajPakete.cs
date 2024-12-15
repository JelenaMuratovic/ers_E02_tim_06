using Domain.Models;
using Domain.Services;
using Prezentacija.GenerisanjePaketa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repozitorijumi.PaketiRepozitorijum;

namespace Prezentacija.KreiranjePaketa
{
    public class KreirajPakete : IKreiranjePaketaServis
    {
        IPaketRepozitorijum paketi = new PaketRepozitorijum();

        public KreirajPakete(IPaketRepozitorijum prethodniPaketi)
        {
            paketi = prethodniPaketi;
        }

        public IEnumerable<MrezniPaket> KreiranjePaketa(int brojPaketa)
        {
            MrezniPaket mp;
            for (int i = 0; i < brojPaketa; i++)
            {
                mp = new MrezniPaket(NasumicanSadrzaj.GenerisiNasumicanProtokol(),
                    NasumicanSadrzaj.GenerisiNasumicnuVelZaglavlja(),
                    NasumicanSadrzaj.GenerisiNasumicnuVelPodataka(),
                    NasumicanSadrzaj.GenerisiNasumicanSadrzaj(),
                    NasumicanSadrzaj.GenerisiNasumicnuIPAdresu());
                paketi.DodajPaket(mp);
            }
            return paketi.DobaviPakete();
        }
    }
}
