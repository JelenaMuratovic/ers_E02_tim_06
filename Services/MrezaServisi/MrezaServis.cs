using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using Services.EvidencijaServisi;

namespace Services.MrezaServisi
{
    public class MrezaServis : IMrezaServis
    {
        private IAutentifikacijaServis auth;
        private IEvidencijaServis fileUpis;
        private ISlanjePaketaServis slanjePaketaServis;

        public MrezaServis(IAutentifikacijaServis auth, IEvidencijaServis fileUpis, ISlanjePaketaServis slanjePaketaServis)
        {
            this.auth = auth;
            this.fileUpis = fileUpis;
            this.slanjePaketaServis = slanjePaketaServis;
        }

        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi)
        {
            return slanjePaketaServis.PosaljiPakete(paketi);
        }

        public (bool, Korisnik) Prijava(string KorisnickoIme, string Lozinka)
        {
            return auth.Prijava(KorisnickoIme, Lozinka);
        }

        public void Upisi(string paket)
        {
            fileUpis.Upisi(paket);
        }


    }
}
