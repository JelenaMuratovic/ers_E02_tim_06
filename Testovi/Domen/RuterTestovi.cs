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
    public class RuterTestovi
    {
        [Test]
        [TestCase("345", 300, 22, VrstaRutera.BEZICNI)]
        [TestCase("456", 400, 35, VrstaRutera.OBICNI)]
        [TestCase("346", 200, 12, VrstaRutera.BEZICNI)]
        public void RuterKonstruktorDobar(string serijskiBroj, int brzinaPrenosa, int brojLANPrikljucka, VrstaRutera vrstaRutera)
        {
            Ruter ruter = new Ruter(serijskiBroj, brzinaPrenosa, brojLANPrikljucka, vrstaRutera);
            Assert.That(ruter, Is.Not.Null);
            Assert.That(ruter.SerijskiBrojProizvodjaca, Is.EqualTo(serijskiBroj));
            Assert.That(ruter.MaxBrzinaPrenosaPodataka, Is.EqualTo(brzinaPrenosa));
            Assert.That(ruter.BrojLANPrikljucka, Is.EqualTo(brojLANPrikljucka));
            Assert.That(ruter.VrstaRutera, Is.EqualTo(vrstaRutera));
        }
    }
}
