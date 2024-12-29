using Domain.Models;

namespace Domain.PomocneMetode
{
    public class KreirajRacunar
    {
        public Racunar KreiranjeRacunara()
        {
            return new Racunar(NasumicnoGenerisanjeRacunara.GenerisiSerijskiBroj(),
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanKapacitetRadneMemorije(),
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanKapacitetSkladisneMemorije(),
                                NasumicnoGenerisanjeRacunara.GenerisiNasumicanTipSkladisneMemorije(),
                                NasumicnoGenerisanjeRacunara.GenerisiLokalnuIPAdresu());
        }
    }
}
