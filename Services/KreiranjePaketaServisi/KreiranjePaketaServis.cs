using Domain.Models;
using Domain.Services;
using Prezentacija.GenerisanjePaketa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.KreiranjePaketaServisi
{
    public class KreiranjePaketaServis : IKreiranjePaketaServis
    {

        public IEnumerable<MrezniPaket> KreirajPakete(int brojPaketa)
        {
            MrezniPaket mp;
            List<MrezniPaket> paketi = new List<MrezniPaket>();
            for(int i = 0; i < brojPaketa; i++)
            {
                mp = new MrezniPaket(NasumicanSadrzaj.GenerisiNasumicanProtokol(),
                    NasumicanSadrzaj.GenerisiNasumicnuVelZaglavlja(),
                    NasumicanSadrzaj.GenerisiNasumicnuVelPodataka(),
                    NasumicanSadrzaj.GenerisiNasumicanSadrzaj(),
                    NasumicanSadrzaj.GenerisiNasumicnuIPAdresu());
                paketi.Add(mp);
            }
            return paketi;
        }
    }
}
