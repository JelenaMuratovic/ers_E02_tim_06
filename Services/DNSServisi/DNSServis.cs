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
        IEvidencijaServis evidencija = new FileEvidencijaServis();
        IPregledEvidencijeServis pregledEvidencije;

        public DNSServis()
        {
        }

        public DNSServis(IPregledEvidencijeServis pregledEvidencije)
        {
            this.pregledEvidencije = pregledEvidencije;
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
