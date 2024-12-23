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
        public KreirajPakete()
        {
        }

        public IEnumerable<MrezniPaket> KreiranjePaketa(int brojPaketa)
        {
            MrezniPaket mp;
            List<MrezniPaket> kreiraniPaketi = new List<MrezniPaket>();
            for (int i = 0; i < brojPaketa; i++)
            {
                mp = new MrezniPaket(NasumicanSadrzajPaketa.GenerisiNasumicanProtokol(),
                    NasumicanSadrzajPaketa.GenerisiNasumicnuVelZaglavlja(),
                    NasumicanSadrzajPaketa.GenerisiNasumicnuVelPodataka(),
                    NasumicanSadrzajPaketa.GenerisiNasumicanSadrzaj(),
                    NasumicanSadrzajPaketa.GenerisiNasumicnuIPAdresu());
                kreiraniPaketi.Add(mp);
            }

            return kreiraniPaketi;
        }
    }
}
