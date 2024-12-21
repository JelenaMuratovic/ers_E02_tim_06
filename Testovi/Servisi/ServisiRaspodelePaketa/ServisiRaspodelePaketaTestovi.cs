using Domain.Models;
using Domain.Repozitorijumi.PaketiRepozitorijum;
using Domain.Repozitorijumi.RacunariRepozitorijum;
using Domain.Repozitorijumi.RuteriRepozitorijum;
using Domain.Services;
using Moq;
using NUnit.Framework;
using Services;
using Services.DNSServisi;
using Services.RuterServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testovi.Servisi.ServisiRaspodelePaketa
{
    [TestFixture]
    public class ServisiRaspodelePaketaTestovi
    {
        Mock<IRacunarRepozitorijum> _racunariRepozitorijum;
        Mock<IPaketRepozitorijum> _paketRepozitorijum;

        IRasporediPakete _rasporediPaketeServis;

        public ServisiRaspodelePaketaTestovi()
        {
            _racunariRepozitorijum = new Mock<IRacunarRepozitorijum>();
            _paketRepozitorijum = new Mock<IPaketRepozitorijum>();

            _rasporediPaketeServis = new RasporediPaketeServis(_racunariRepozitorijum.Object, _paketRepozitorijum.Object);
        }

        [SetUp]
        public void Setup()
        {
            _racunariRepozitorijum = new Mock<IRacunarRepozitorijum>();
            _paketRepozitorijum = new Mock<IPaketRepozitorijum>();

            _rasporediPaketeServis = new RasporediPaketeServis(_racunariRepozitorijum.Object, _paketRepozitorijum.Object);
        }

        [Test]
        [TestCase("192.168.0.1", "192.168.0.2", "192.168.0.3")]
        public void PaketiRasporedjeniNaRacunare_vracaTrue(string ipAdresa1, string ipAdresa2, string ipAdresa3)
        {
            var racunariLista = new List<Racunar>
            {
                new Racunar("",0,0,0,ipAdresa1),
                new Racunar("",0,0,0,ipAdresa2),
                new Racunar("",0,0,0,ipAdresa3)
            };

            var paketiLista = new List<MrezniPaket>
            {
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"",""),
                new MrezniPaket(0,0,0,"","")
            };

            _racunariRepozitorijum.Setup(r => r.DobaviRacunare()).Returns(racunariLista);
            _paketRepozitorijum.Setup(p => p.DobaviPakete()).Returns(paketiLista);

            var rezultat = _rasporediPaketeServis.RasporediPaketeRacunarima();

            Assert.That(rezultat, Is.True);

            Assert.That(paketiLista[0].IPAdresaPosiljaoca, Is.EqualTo("192.168.0.1"));
            Assert.That(paketiLista[1].IPAdresaPosiljaoca, Is.EqualTo("192.168.0.2"));
            Assert.That(paketiLista[2].IPAdresaPosiljaoca, Is.EqualTo("192.168.0.3"));
        }

        [Test]
        [TestCase("192.168.0.1")]
        public void RasporediPaketeRacunarima_NemaPaketa_VracaFalse(string ipAdresa)
        {
            var racunariLista = new List<Racunar>
            {
                new Racunar("",0,0,0,ipAdresa),
            };

            var paketiLista = new List<MrezniPaket>(); 

            _racunariRepozitorijum.Setup(r => r.DobaviRacunare()).Returns(racunariLista);
            _paketRepozitorijum.Setup(p => p.DobaviPakete()).Returns(paketiLista);

            var rezultat = _rasporediPaketeServis.RasporediPaketeRacunarima();

            Assert.That(rezultat, Is.False);
        }

        [Test]
        public void RasporediPaketeRacunarima_NemaRacunara_VracaFalse()
        {
            var racunariLista = new List<Racunar>();

            var paketiLista = new List<MrezniPaket>
            {
                new MrezniPaket(0,0,0,"","")
            };

            _racunariRepozitorijum.Setup(r => r.DobaviRacunare()).Returns(racunariLista);
            _paketRepozitorijum.Setup(p => p.DobaviPakete()).Returns(paketiLista);

            var rezultat = _rasporediPaketeServis.RasporediPaketeRacunarima();

            Assert.That(rezultat, Is.False);
        }


    }
    
}
