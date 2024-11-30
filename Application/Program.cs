using Domain.Models;
using Domain.Services;
using Prezentacija.Autentifikacija;
using Services.AutentifikacioniServisi;
using Services.EvidencijaServisi;
using Services.KreiranjePaketaServisi;
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
            IKreiranjePaketaServis kreiranjePaketaServis = new KreiranjePaketaServis();
            ISlanjePaketaServis slanjePaketaServis = new SlanjePaketaRavnomernoServis();
            IMrezaServis mrezaServis = new MrezaServis(autentifikacijaServis, evidencijaServis, kreiranjePaketaServis, slanjePaketaServis);

            var auth = new AutentifikacijaKorisnika(autentifikacijaServis, mrezaServis);
            if (!auth.UlogujSe(out Korisnik korisnik)) return;

            
        }
    }
}
