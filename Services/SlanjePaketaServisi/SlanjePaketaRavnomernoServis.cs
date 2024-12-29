using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;

namespace Services.SlanjePaketaServisi
{
    public class SlanjePaketaRavnomernoServis : ISlanjePaketaServis
    {
        public IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        public IPaketRepozitorijum paketi = new PaketRepozitorijum();
        public IRuterServis ruterServis;

        public SlanjePaketaRavnomernoServis(IRuterServis ruterServis)
        {
            this.ruterServis = ruterServis;
        }

        public bool PosaljiPakete()//promeniti
        {
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            var paketi_lista = paketi.DobaviPakete().ToList();
            if (ruteri_lista.Count == 0 || paketi_lista.Count == 0 || ruteri_lista == null || paketi_lista == null)
                return false;
            for (int i = 0; i < paketi_lista.Count(); i++)
            {
                if (!paketi_lista[i].Poslat)
                {
                    paketi_lista[i].Poslat = true;
                    string serijskiBroj = ruteri_lista[i % ruteri_lista.Count()].SerijskiBrojProizvodjaca;
                    ruterServis.PrimiPaket(serijskiBroj, paketi_lista[i]);
                }
            }
            return true;
        }
    }

}
