using Domain.Models;

namespace Domain.PomocneMetode
{
    public class KreirajPakete
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
