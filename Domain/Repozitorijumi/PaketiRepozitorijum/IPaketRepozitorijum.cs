using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repozitorijumi.PaketiRepozitorijum
{
    public interface IPaketRepozitorijum
    {
        public void DodajPaket(MrezniPaket paket);
        public IEnumerable<MrezniPaket> DobaviPakete();
    }
}
