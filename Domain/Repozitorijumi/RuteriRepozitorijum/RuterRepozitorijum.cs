using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Repozitorijumi.RuteriRepozitorijum
{
    public class RuterRepozitorijum : IRuterRepozitorijum
    {
        private static List<Ruter> ruteri;
        static RuterRepozitorijum()
        {
            ruteri =
                [
                    new("SDFJ893", 300, 89, VrstaRutera.OBICNI),
                    new("ANDK900", 500, 32, VrstaRutera.BEZICNI),
                    new("LNSUD898", 200, 23, VrstaRutera.OBICNI),
                    new("SJNDS894", 350, 12, VrstaRutera.BEZICNI)
                ];
        }
        public IEnumerable<Ruter> DobaviRutere()
        {
            return ruteri;
        }
    }
}
