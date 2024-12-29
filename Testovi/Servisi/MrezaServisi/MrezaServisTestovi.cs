using Domain.Models;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services.MrezaServisi;

namespace Testovi.Servisi.MrezaServisi
{
    [TestFixture]
    public class MrezaServisTestovi
    {
        Mock<IAutentifikacijaServis> _authServis;
        Mock<ISlanjePaketaServis> _slanjePaketaServis;
        Mock<IDNServis> _dnsServis;
        Mock<IRacunarRepozitorijum> _racunariRepozitorijum;
        Mock<IRuterRepozitorijum> _ruteriRepozitorijum;
        Mock<IPregledEvidencijeServis> _PregledEvidencijeServis;

        IMrezaServis _servis;

        public MrezaServisTestovi()
        {
            _authServis = new Mock<IAutentifikacijaServis>();
            _slanjePaketaServis = new Mock<ISlanjePaketaServis>();
            _dnsServis = new Mock<IDNServis>();
            _racunariRepozitorijum = new Mock<IRacunarRepozitorijum>();
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _PregledEvidencijeServis = new Mock<IPregledEvidencijeServis>();

            _servis = new MrezaServis(_authServis.Object, _slanjePaketaServis.Object, _dnsServis.Object);
        }

        [SetUp]
        public void Setup()
        {
            _authServis = new Mock<IAutentifikacijaServis>();
            _slanjePaketaServis = new Mock<ISlanjePaketaServis>();
            _dnsServis = new Mock<IDNServis>();
            _racunariRepozitorijum = new Mock<IRacunarRepozitorijum>();
            _ruteriRepozitorijum = new Mock<IRuterRepozitorijum>();
            _PregledEvidencijeServis = new Mock<IPregledEvidencijeServis>();

            _servis = new MrezaServis(_authServis.Object, _slanjePaketaServis.Object, _dnsServis.Object)
            {
                Racunari = _racunariRepozitorijum.Object,
                Ruteri = _ruteriRepozitorijum.Object
            };

            _authServis.Setup(p => p.Prijava(It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            _slanjePaketaServis.Setup(p => p.PosaljiPakete()).Verifiable();
            _dnsServis.Setup(d => d.Evidentiraj(It.IsAny<IEnumerable<MrezniPaket>>()))
            .Returns((IEnumerable<MrezniPaket> paketi) => _PregledEvidencijeServis.Object.Pregled(paketi));
        }

        [Test]
        [TestCase("126")]
        public void dodavanjeRacunara_vracaTrue(string serijskiBroj)
        {
            var racunar = new Racunar(serijskiBroj, 0, 0, 0, "");
            var ocekivanaLista = new List<Racunar> { racunar };

            _racunariRepozitorijum.Setup(p => p.DodajRacunar(racunar)).Returns(true);
            _racunariRepozitorijum.Setup(p => p.DobaviRacunare()).Returns(ocekivanaLista);

            var rezultat = _servis.DodajRacunar(racunar);
            var lista = _racunariRepozitorijum.Object.DobaviRacunare();

            Assert.That(rezultat, Is.True);
            Assert.That(lista.Count, Is.EqualTo(1));
            _racunariRepozitorijum.Verify(r => r.DodajRacunar(racunar), Times.Once);//DodajRacunar pozvana tacno jednom
            _racunariRepozitorijum.Verify(r => r.DobaviRacunare(), Times.Once);
        }

        [Test]
        [TestCase("227")]
        public void dodavanjeRutera_vracaTrue(string serijskiBroj)
        {
            var ruter = new Ruter(serijskiBroj, 0, 0, 0);
            var ocekivanaLista = new List<Ruter> { ruter };

            _ruteriRepozitorijum.Setup(p => p.DodajRuter(ruter)).Returns(true);
            _ruteriRepozitorijum.Setup(p => p.DobaviRutere()).Returns(ocekivanaLista);

            var rezultat = _servis.DodajRuter(ruter);
            var lista = _ruteriRepozitorijum.Object.DobaviRutere();

            Assert.That(rezultat, Is.True);
            Assert.That(lista.Count, Is.EqualTo(1));
            _ruteriRepozitorijum.Verify(r => r.DodajRuter(ruter), Times.Once);//DodajRuter pozvana tacno jednom
            _ruteriRepozitorijum.Verify(r => r.DobaviRutere(), Times.Once);
        }

        [Test]
        [TestCase("126", "127", "128")]
        public void brisanjeRacunara_vracaTrue(string serijskiBroj1, string serijskiBroj2, string serijskiBroj3)
        {
            var racunar1 = new Racunar(serijskiBroj1, 0, 0, 0, "");
            var racunar2 = new Racunar(serijskiBroj2, 0, 0, 0, "");
            var racunar3 = new Racunar(serijskiBroj3, 0, 0, 0, "");
            var racunari = new List<Racunar> { racunar1, racunar2, racunar3 };

            _racunariRepozitorijum.Setup(p => p.DobaviRacunare()).Returns(racunari);
            _racunariRepozitorijum.Setup(r => r.ObrisiRacunar(serijskiBroj2))
            .Callback<string>(serijskiBroj =>
            {
                var racunarZaBrisanje = racunari.FirstOrDefault(r => r.SerijskiBrojProizvodjaca == serijskiBroj);
                if (racunarZaBrisanje != null)
                {
                    racunari.Remove(racunarZaBrisanje);
                }
            })
            .Returns(true);


            var rezultat = _servis.ObrisiRacunar(serijskiBroj2);
            var lista = _racunariRepozitorijum.Object.DobaviRacunare();

            Assert.That(rezultat, Is.True);
            Assert.That(lista.Count, Is.EqualTo(2));
            _racunariRepozitorijum.Verify(r => r.DobaviRacunare(), Times.Once);
        }

        [Test]
        public void EvidentirajVracaOdgovarajuciString()
        {
            var listaPaketa = new List<MrezniPaket>
            {
                new MrezniPaket(0,20,50,"data1","192.168.10.1"),
                new MrezniPaket(0,10,30,"data2","192.168.10.2"),
                new MrezniPaket(0,20,20,"data3","192.168.10.3")
            };

            var ocekivaniString =
                "Protokol: SMTP Header len: 20 App len: 50 Data: data1 Destination IP addr: 192.168.10.1\n" +
                "Protokol: SMTP Header len: 20 App len: 50 Data: data1 Destination IP addr: 192.168.10.1\n" +
                "Protokol: SMTP Header len: 20 App len: 50 Data: data1 Destination IP addr: 192.168.10.1\n";

            _PregledEvidencijeServis
                .Setup(p => p.Pregled(It.IsAny<IEnumerable<MrezniPaket>>()))
                .Returns(ocekivaniString);

            var rezultat = _servis.PregledPaketa(listaPaketa);

            Assert.That(rezultat, Is.EqualTo(ocekivaniString));

            _dnsServis.Verify(d => d.Evidentiraj(listaPaketa), Times.Once);
            _PregledEvidencijeServis.Verify(p => p.Pregled(listaPaketa), Times.Once);
        }
    }
}
