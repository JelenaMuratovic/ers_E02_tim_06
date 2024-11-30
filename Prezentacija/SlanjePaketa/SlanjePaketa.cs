using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prezentacija.SlanjePaketa
{
    public class SlanjePaketa
    {
        private ISlanjePaketaServis slanjeServis;
        private int brojPaketa;
        private int tipSlanja;

        public SlanjePaketa(ISlanjePaketaServis slanjeServis, int brojPaketa, int tipSlanja)
        {
            this.slanjeServis = slanjeServis;
            this.brojPaketa = brojPaketa;
            this.tipSlanja = tipSlanja;
        }

        public bool PosaljiPakete()
        {
            //kreiramo pakete prvo
            //onda da ih posaljemo
            List<MrezniPaket> paketiZaSlanje = new List<MrezniPaket>();
            //paketiZaSlanje = slanjeServis.KreirajPakete(brojPaketa) as List<MrezniPaket> ?? [];
            if (tipSlanja == 1)
            {
                slanjeServis = new SlanjePaketaRavnomernoServis();
            } else
            {

            }
            return true;
        }
    }
}
