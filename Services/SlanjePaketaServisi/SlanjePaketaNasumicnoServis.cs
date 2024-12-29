using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;

namespace Services.SlanjePaketaServisi
{
    public class SlanjePaketaNasumicnoServis : ISlanjePaketaServis
    {

        public IRuterServis ruterServis;
        public IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        public IPaketRepozitorijum paketi = new PaketRepozitorijum();

        public SlanjePaketaNasumicnoServis(IRuterServis ruterServis)
        {
            this.ruterServis = ruterServis;
        }

        public bool PosaljiPakete()
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            if (ruteri_lista.Count() == 0 || ruteri_lista == null)
            {
                return false;
            }

            foreach (MrezniPaket paket in paketi.DobaviPakete())
            {
                paket.Poslat = true;
                string serijskiBroj = ruteri_lista[new Random().Next(0, ruteri_lista.Count() - 1)].SerijskiBrojProizvodjaca;
                ruterServis.PrimiPaket(serijskiBroj, paket);
            }
            return true;
        }
    }
}
