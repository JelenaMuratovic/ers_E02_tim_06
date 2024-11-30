using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.Autentifikacija
{
    public class AutentifikacijaKorisnika
    {
        private readonly IAutentifikacijaServis autentifikacijaServis;
        private readonly IMrezaServis mrezaServis;

        public AutentifikacijaKorisnika(IAutentifikacijaServis autentifikacijaServis, IMrezaServis servis)
        {
            this.autentifikacijaServis = autentifikacijaServis;
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
