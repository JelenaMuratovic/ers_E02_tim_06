using Domain.Models;
using Domain.Services;

namespace Prezentacija.Autentifikacija
{
    public class AutentifikacijaKorisnika
    {
        private readonly IMrezaServis mrezaServis;

        public AutentifikacijaKorisnika(IMrezaServis servis)
        {
            this.mrezaServis = servis;
        }

        public bool UlogujSe(out Korisnik korisnik)
        {
            korisnik = new Korisnik();
            bool uspesnaPrijava = false;
            string? korisnickoIme = "", lozinka = "";

            while (!uspesnaPrijava)
            {
                Console.Write("Korisničko ime: ");
                korisnickoIme = Console.ReadLine() ?? "";

                Console.Write("Lozinka: ");
                lozinka = Console.ReadLine() ?? "";

                (uspesnaPrijava, korisnik) = mrezaServis.Prijava(korisnickoIme.Trim(), lozinka.Trim());
            }

            return uspesnaPrijava;
        }
    }
}
