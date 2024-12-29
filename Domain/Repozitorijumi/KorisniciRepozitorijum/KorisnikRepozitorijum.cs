using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.KorisniciRepozitorijum
{
    public class KorisnikRepozitorijum : IKorisnikRepozitorijum
    {
        private static readonly List<Korisnik> korisnici;
        static KorisnikRepozitorijum()
        {
            korisnici =
                [
                    new("Neca", "suncano20", "Nevena Gatalo"),
                    new("Jeca", "kisovito40", "Jelena Muratovic")
                ];
        }

        public IEnumerable<Korisnik> DobaviKorisnike()
        {
            return korisnici;
        }
    }
}
