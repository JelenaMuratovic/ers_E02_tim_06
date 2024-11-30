using Domain.Models;
using Domain.Services;
using Prezentacija.Autentifikacija;
using Services.AutentifikacioniServisi;
using Services.EvidencijaServisi;
using Services.MrezaServisi;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();
            IEvidencijaServis evidencijaServis = new FileEvidencijaServis();
            IMrezaServis mrezaServis = new MrezaServis(autentifikacijaServis, evidencijaServis);

            var auth = new AutentifikacijaKorisnika(autentifikacijaServis, mrezaServis);
            if (!auth.UlogujSe(out Korisnik korisnik)) return;

            
        }
    }
}
