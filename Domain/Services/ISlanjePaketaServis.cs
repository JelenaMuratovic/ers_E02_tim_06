using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ISlanjePaketaServis
    {
        public bool PosaljiPakete(IEnumerable<MrezniPaket> paketi);
        public bool RasporediPakete(IEnumerable<MrezniPaket> paketi);
    }
}
