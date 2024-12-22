using Domain.Models;
using Domain.Services;
using Services.EvidencijaServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DNSServisi
{
    public class DNSServis : IDNServis
    {
        IEvidencijaServis evidencija;
        IPregledEvidencijeServis pregledEvidencije;


        public DNSServis(IPregledEvidencijeServis pregledEvidencije, IEvidencijaServis evidencija)
        {
            this.pregledEvidencije = pregledEvidencije;
            this.evidencija = evidencija;
        }

        public string Evidentiraj(IEnumerable<MrezniPaket> listaPaketa)
        {
            return pregledEvidencije.Pregled(listaPaketa);
        }

        public bool PrimiPaket(MrezniPaket paket)
        {
            if (paket == null)
            {
                return false;
            }
            evidencija.Upisi(paket.ToString());
            return true;
        }
    }
}
