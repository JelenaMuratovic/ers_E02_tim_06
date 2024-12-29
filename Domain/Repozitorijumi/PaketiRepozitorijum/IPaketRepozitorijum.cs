using Domain.Models;

namespace Domain.Repozitorijumi.PaketiRepozitorijum
{
    public interface IPaketRepozitorijum
    {
        public void DodajPaket(MrezniPaket paket);
        public IEnumerable<MrezniPaket> DobaviPakete();
    }
}
