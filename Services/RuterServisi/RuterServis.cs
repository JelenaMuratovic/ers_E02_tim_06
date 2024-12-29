using Domain.Models;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;

namespace Services.RuterServisi
{
    public class RuterServis : IRuterServis
    {
        public IRuterRepozitorijum ruteri = new RuterRepozitorijum();
        public IDNServis dns;
        public RuterServis(IDNServis dns)
        {
            this.dns = dns;
        }

        public bool PrimiPaket(string serijskiBroj, MrezniPaket? paket)
        {
            if (paket == null)
                return false;
            var ruteri_lista = ruteri.DobaviRutere().ToList();
            foreach (Ruter r in ruteri_lista)
            {
                if (r.SerijskiBrojProizvodjaca == serijskiBroj)
                {
                    r.BrojPaketa++;
                    return dns.PrimiPaket(paket);
                }
            }

            return false;
        }
    }
}
