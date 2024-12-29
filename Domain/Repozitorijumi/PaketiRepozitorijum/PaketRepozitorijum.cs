using Domain.Models;

namespace Domain.Repozitorijumi.PaketiRepozitorijum
{
    public class PaketRepozitorijum : IPaketRepozitorijum
    {
        private static List<MrezniPaket> paketi = new List<MrezniPaket>();

        public IEnumerable<MrezniPaket> DobaviPakete()
        {
            return paketi;
        }

        public void DodajPaket(MrezniPaket paket)
        {
            paketi.Add(paket);
        }
    }
}
