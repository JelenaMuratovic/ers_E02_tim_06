using Domain.Models;
using Domain.Repozitorijumi.KorisniciRepozitorijum;
using Domain.Services;

namespace Services.AutentifikacioniServisi
{
    public class AutentifikacioniServis : IAutentifikacijaServis
    {
        private IKorisnikRepozitorijum korisniciRepozitorijum = new KorisnikRepozitorijum();

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            var korisnici = korisniciRepozitorijum.DobaviKorisnike();
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme.Equals(KorisnickoIme) && k.Lozinka.Equals(Lozinka))
                    return (true, k);
            }

            return (false, new Korisnik());
        }
    }
}
