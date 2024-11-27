using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class DNS
    {
        public string IPAdresa { get; set; } = "";
        public int MaxBrojPovezanihUredjaja {  get; set; }
        public string SimbolickaAdresa { get; set; } = "";
        public OperativnoStanje OperativnoStanje { get; set; }
    }
}
