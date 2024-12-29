using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.KorisniciRepozitorijum
{
    public interface IKorisnikRepozitorijum
    {
        public IEnumerable<Korisnik> DobaviKorisnike();
    }
}
