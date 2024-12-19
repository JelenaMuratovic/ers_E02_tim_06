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
    public class MrezniPaketTestovi
    {
        [Test]
        [TestCase(MrezniProtokol.SMTP, 50, 1050, "sadrzaj smtp paketa", "192.168.10.1")]
        [TestCase(MrezniProtokol.HTTP, 45, 2910, "zdravo", "192.168.10.67")]
        [TestCase(MrezniProtokol.HTTPS, 20, 300, "pronadji ovaj sajt", "192.168.10.2")]
        public void MrezniPaketKonstuktorDobar(MrezniProtokol mp, int velZaglavlja, int velDelaSaPodacima, string sadrzaj, string IPAdresaPrimaoca)
        {
            MrezniPaket paket = new MrezniPaket(mp, velZaglavlja, velDelaSaPodacima, sadrzaj, IPAdresaPrimaoca);
            Assert.That(paket, Is.Not.Null);
            Assert.That(paket.Protokol, Is.EqualTo(mp));
            Assert.That(paket.VelicinaZaglavlja, Is.EqualTo(velZaglavlja));
            Assert.That(paket.VelicinaDelaSaPodacima, Is.EqualTo(velDelaSaPodacima));
            Assert.That(paket.IPAdresaPrimaoca, Is.EqualTo(IPAdresaPrimaoca));
        }
        [Test]
        [TestCase(MrezniProtokol.SMTP, 50, 1050, "sadrzaj smtp paketa", "192.168.10.1")]
        [TestCase(MrezniProtokol.HTTP, 45, 2910, "zdravo", "192.168.10.67")]
        [TestCase(MrezniProtokol.HTTPS, 20, 300, "pronadji ovaj sajt", "192.168.10.2")]
        public void MrezniPaketKonstruktor_ProveriProperty(MrezniProtokol mp, int velZaglavlja, int velDelaSaPodacima, string sadrzaj, string IPAdresaPrimaoca)
        {
            MrezniPaket paket = new MrezniPaket(mp, velZaglavlja, velDelaSaPodacima, sadrzaj, IPAdresaPrimaoca);
            string noviSadrzaj = "novi sadrzaj paketa";
            paket.Sadrzaj = noviSadrzaj;
            Assert.That(paket, Is.Not.Null);
            Assert.That(paket.Sadrzaj, Is.EqualTo(noviSadrzaj));
        }
    }
}
