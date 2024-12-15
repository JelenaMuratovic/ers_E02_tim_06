using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PregledEvidencijeServisi
{
    public class PregledEvidencijeKonzolaServis : IPregledEvidencijeServis
    {
        public string Pregled(IEnumerable<MrezniPaket> listaPaketa)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(MrezniPaket paket in listaPaketa)
            {
                stringBuilder.Append(paket.ToString()+'\n');
            }
            return stringBuilder.ToString();
        }
    }
}
