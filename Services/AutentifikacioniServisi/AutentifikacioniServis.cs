using Domain.Models;
using Domain.Services;

namespace Services.AutentifikacioniServisi
{
    public class AutentifikacioniServis : IAutentifikacijaServis
    {
        private static readonly List<Korisnik> korisnici;

        static AutentifikacioniServis()
        {
            korisnici =
                [
                    new("Neca", "suncano20", "Nevena Gatalo"),
                    new("Jeca", "kisovito40", "Jelena Muratovic")
                ];
        }

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme.Equals(KorisnickoIme) && k.Lozinka.Equals(Lozinka))
                    return (true, k);
            }

            return (false, new Korisnik());
        }
    }
}
