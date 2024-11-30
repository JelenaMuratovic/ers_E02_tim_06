using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MrezniPaket
    {
        public MrezniProtokol Protokol { get; set; }
        public int VelicinaZaglavlja { get; set; }
        public int VelicinaDelaSaPodacima { get; set; }
        public string Sadrzaj { get; set; } = "";
        public string IPAdresaPrimaoca { get; set; } = "";

        public override string? ToString()
        {
            return "Protokol: " + Protokol + " " + "Header len: " + VelicinaZaglavlja + " App len: " + VelicinaDelaSaPodacima + " Data: " + Sadrzaj + "Destination IP addr: " + IPAdresaPrimaoca;
        }
    }
}
