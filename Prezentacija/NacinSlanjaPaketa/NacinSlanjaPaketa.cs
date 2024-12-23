using Domain.Models;
using Domain.Services;
using Services.SlanjePaketaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.NacinSlanjaPaketa
{
    public class NacinSlanjaPaketa
    {
        private ISlanjePaketaServis slanjePaketaServis;
        private int brojPaketa { get; set; }
        private int tipSlanja {  get; set; }

        public NacinSlanjaPaketa(ISlanjePaketaServis slanjePaketaServis, int brojPaketa, int tipSlanja)
        {
            this.slanjePaketaServis = slanjePaketaServis;
            this.brojPaketa = brojPaketa;
            this.tipSlanja = tipSlanja;
        }

    }
}
