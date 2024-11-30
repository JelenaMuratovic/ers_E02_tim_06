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

        public MrezaServis(IAutentifikacijaServis auth, IEvidencijaServis fileUpis)
        {
            this.auth = auth;
            this.fileUpis = fileUpis;
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
