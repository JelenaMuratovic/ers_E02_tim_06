using Domain.Models;

namespace Domain.Repozitorijumi.RacunariRepozitorijum
{
    public interface IRacunarRepozitorijum
    {
        public bool DodajRacunar(Racunar racunar);
        public bool ObrisiRacunar(string SerijskiBroj);
        public IEnumerable<Racunar> DobaviRacunare();
    }
}
