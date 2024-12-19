using Domain.Enums;
using Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovi.Domen
{
    [TestFixture]
    public class RacunarTestovi
    {
        [Test]
        [TestCase("123", 16, 256, TipSkladisneMemorije.SSD, "192.168.10.1")]
        [TestCase("567", 32, 1024, TipSkladisneMemorije.SSD, "192.168.10.3")]
        [TestCase("789", 66, 512, TipSkladisneMemorije.HDD, "192.168.10.7")]
        public void RacunarKonstruktorDobar(string serijskiBroj, int radnaMemorija, int skladisnaMemorija, TipSkladisneMemorije skladisnaMemorijaTip, string lokalnaIPAdresa)
        {
            Racunar racunar = new Racunar(serijskiBroj, radnaMemorija, skladisnaMemorija, skladisnaMemorijaTip, lokalnaIPAdresa);
            Assert.That(racunar, Is.Not.Null);
            Assert.That(racunar.SerijskiBrojProizvodjaca, Is.EqualTo(serijskiBroj));
            Assert.That(racunar.KapacitetRadneMemorije, Is.EqualTo(radnaMemorija));
            Assert.That(racunar.KapacitetSkladisneMemorije, Is.EqualTo(skladisnaMemorija));
            Assert.That(racunar.TipSkladisneMemorije, Is.EqualTo(skladisnaMemorijaTip));
            Assert.That(racunar.LokalnaIPAdresa, Is.EqualTo(lokalnaIPAdresa));
        }
    }
}
