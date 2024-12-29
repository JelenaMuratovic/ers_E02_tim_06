using Domain.Models;
using NUnit.Framework;

namespace Testovi.Domen
{
    [TestFixture]
    public class KorisnikTestovi
    {
        [Test]
        [TestCase("Tijana", "456", "Tijana Tijanic")]
        [TestCase("Mirjana", "mojaSifra34", "Mirjana Mirjanic")]
        [TestCase("Ana", "/a'sf", "Ana Marijanovic")]
        public void KorisnikKonstruktorDobar(string korisnickoIme, string lozinka, string imePrezime)
        {
            Korisnik korisnik = new Korisnik(korisnickoIme, lozinka, imePrezime);
            Assert.That(korisnik, Is.Not.Null);
            Assert.That(korisnik.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(korisnik.Lozinka, Is.EqualTo(lozinka));
            Assert.That(korisnik.ImePrezime, Is.EqualTo(imePrezime));
        }
    }
}
