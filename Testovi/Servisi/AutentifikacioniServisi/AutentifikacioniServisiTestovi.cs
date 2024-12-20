using Domain.Models;
using Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovi.Servisi.AutentifikacioniServisi
{
    [TestFixture]
    public class AutentifikacioniServisiTestovi
    {
        Mock<IAutentifikacijaServis> _authServis;

        public AutentifikacioniServisiTestovi() => _authServis = new Mock<IAutentifikacijaServis>();

        [SetUp]
        public void Setup()
        {
            _authServis = new Mock<IAutentifikacijaServis>();
        }

        [Test]
        [TestCase("Neca", "suncano20")]

        public void PrijavaSaIspravnimPodacima_VracaTrue(string korisnickoIme, string lozinka)
        {
            var korisnik = new Korisnik(korisnickoIme, lozinka, "");

            _authServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((true, korisnik));

            (bool uspesnaAutentifikacija, Korisnik prijavljen) = _authServis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesnaAutentifikacija, Is.True);
            Assert.That(prijavljen, Is.Not.Null);
            Assert.That(prijavljen.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(prijavljen.Lozinka, Is.EqualTo(lozinka));
        }

        [Test]
        [TestCase("Mica", "oblacno50")]
        [TestCase("Tica", "vedro10")]
        public void PrijavaSaNeispravnimPodacima_vracaFalse(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik;

            _authServis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((false, new Korisnik()));

            (bool uspesnaAutentifikacija, korisnik) = _authServis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesnaAutentifikacija, Is.False);
            Assert.That(korisnik.KorisnickoIme, Is.Empty);
        }
    }
}
