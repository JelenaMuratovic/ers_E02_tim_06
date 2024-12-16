using Domain.Models;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.PregledEvidencijeServisi
{
    public class PregledEvidencijeXMLServis : IPregledEvidencijeServis
    {
        public string Pregled(IEnumerable<MrezniPaket> listaPaketa)
        {
            Console.WriteLine("uso");
            string imeFajla = "evidencija.xml";
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(MrezniPaket));
                StreamWriter writer = new StreamWriter(imeFajla, true);
                foreach (MrezniPaket mp in listaPaketa)
                {
                    serialiser.Serialize(writer, mp);
                }
                return "Paketi sacuvani u: " + imeFajla;
            }
            catch(Exception ex)
            {
                return "Greska pri upisivanju u xml fajl: " + ex.Message;
            }
        }
    }
}
