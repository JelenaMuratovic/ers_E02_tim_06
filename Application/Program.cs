using Domain.Models;
using Domain.Services;
using Prezentacija.Autentifikacija;
using Prezentacija.Meni;
using Services.AutentifikacioniServisi;
using Services.EvidencijaServisi;
using Prezentacija.KreiranjePaketa;
using Services.MrezaServisi;
using Services.SlanjePaketaServisi;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();
            IEvidencijaServis evidencijaServis = new FileEvidencijaServis();
            ISlanjePaketaServis slanjePaketaServis = new SlanjePaketaRavnomernoServis();
            IMrezaServis mrezaServis = new MrezaServis(autentifikacijaServis, evidencijaServis, slanjePaketaServis);

            var auth = new AutentifikacijaKorisnika(autentifikacijaServis, mrezaServis);
            if (!auth.UlogujSe(out Korisnik korisnik)) return;

            var meni = new IspisMenija(mrezaServis);
            meni.PrikaziMeni();

            
        }
    }
}
