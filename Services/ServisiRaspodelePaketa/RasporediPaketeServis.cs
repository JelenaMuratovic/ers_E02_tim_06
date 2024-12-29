using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Services;

namespace Services.ServisiRaspodelePaketa
{
    public class RasporediPaketeServis : IRasporediPakete
    {

        public IRacunarRepozitorijum racunari = new RacunarRepozitorijum();
        public IPaketRepozitorijum paketi = new PaketRepozitorijum();

        public bool RasporediPaketeRacunarima()
        {
            var racunari_lista = racunari.DobaviRacunare().ToList();
            var paketi_lista = paketi.DobaviPakete().ToList();
            if (paketi_lista.Count() == 0 || racunari_lista.Count() == 0 || paketi_lista == null || racunari_lista == null)
            {
                return false;
            }
            for (int i = 0; i < paketi_lista.Count(); i++)
            {
                if (!paketi_lista[i].Poslat)
                {
                    //promena adrese
                    paketi_lista[i].IPAdresaPosiljaoca = racunari_lista[i % racunari_lista.Count()].LokalnaIPAdresa;
                }
            }

            return true;
        }
    }
}
