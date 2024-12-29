using Domain.Models;

namespace Domain.Repozitorijumi.RuteriRepozitorijum
{
    public interface IRuterRepozitorijum
    {
        public IEnumerable<Ruter> DobaviRutere();
        public bool DodajRuter(Ruter ruter);
        public Ruter? DobaviRuterSNajmanjePaketa();
    }
}
