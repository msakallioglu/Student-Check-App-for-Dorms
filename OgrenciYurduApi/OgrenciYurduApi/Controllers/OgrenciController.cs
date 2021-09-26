using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OgrenciYurduApi.Controllers
{
    public class OgrenciController: ApiController
    {
        OgrenciYurduEntities _ent=new OgrenciYurduEntities();

        [HttpGet]
        public List<OgrenciTip> TumOgrencileriGetir()
        {
            return _ent.Ogrenci.Select(p => new OgrenciTip()
            {
                OgrenciID = p.OgrenciID,
                AdSoyad = p.AdSoyad,
                TC = p.TC,
                DogumTarihi = p.DogumTarihi,
                Mail = p.Mail,
                Telefon = p.Telefon,
                AcilDurumTelefon = p.AcilDurumTelefon,
                VeliAdSoyad = p.VeliAdSoyad,
                OdaNumarasi = p.OdaNumarasi,
                Sifre = p.Sifre,
            }).ToList();

        }

        [HttpGet]
        public int OgrenciGirisYap(string TC, string sifre)
        {
            Ogrenci o = _ent.Ogrenci.FirstOrDefault(p => p.TC == TC && p.Sifre == sifre);
            if (o == null)
            {
                return 0;
            }
            else
                return o.OgrenciID;
        }

        [HttpPost]
        public bool OgrenciEkle(Ogrenci veri)
        {
            try
            {
                _ent.Ogrenci.Add(veri);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public List<OgrenciTip> OgrenciSilIDgore(int OgrenciID)
        {
            List<OgrenciIzin> izinkayitlari = _ent.OgrenciIzin.Where(p => p.OgrenciID == OgrenciID).ToList();
            if (izinkayitlari != null)
            {
                _ent.OgrenciIzin.RemoveRange(izinkayitlari);
                _ent.SaveChanges();

            }

            _ent.Ogrenci.Remove(_ent.Ogrenci.Find(OgrenciID));
            _ent.SaveChanges();
            return TumOgrencileriGetir();
        }
        [HttpGet]
        public List<OgrenciTip> IdyeGoreOgrenciGetir(int OgrenciID)
        {
            return _ent.Ogrenci.Where(p => p.OgrenciID == OgrenciID).
               Select(p => new OgrenciTip()
               {
                   OgrenciID = p.OgrenciID,
                   AdSoyad = p.AdSoyad,
                   TC = p.TC,
                   DogumTarihi = p.DogumTarihi,
                   Mail = p.Mail,
                   Telefon = p.Telefon,
                   AcilDurumTelefon = p.AcilDurumTelefon,
                   VeliAdSoyad = p.VeliAdSoyad,
                   OdaNumarasi = p.OdaNumarasi,
               }).ToList();
        }


        [HttpGet]
        public List<OgrenciTip> OgrenciGuncelle(int OgrenciID,string OdaNumarasi,string Mail, string Telefon, string AcilDurumTelefon, string VeliAdSoyad)
        {
            
                Ogrenci o = _ent.Ogrenci.Find(OgrenciID);
                o.Mail = Mail;
                o.Telefon = Telefon;
                o.AcilDurumTelefon =AcilDurumTelefon;
                o.VeliAdSoyad = VeliAdSoyad;
                o.OdaNumarasi = OdaNumarasi;
            _ent.SaveChanges();
            return IdyeGoreOgrenciGetir(OgrenciID);
            
           
        }
        [HttpGet]
        public List<OgrenciTip> OgrenciAraIsmeGore(string kelime)
        {
            return _ent.Ogrenci.Where(p => p.AdSoyad.Contains(kelime)).Select(p => new OgrenciTip()
            {
                OgrenciID = p.OgrenciID,
                AdSoyad = p.AdSoyad,
                TC = p.TC,
                DogumTarihi = p.DogumTarihi,
                Mail = p.Mail,
                Telefon = p.Telefon,
                AcilDurumTelefon = p.AcilDurumTelefon,
                VeliAdSoyad = p.VeliAdSoyad,
                OdaNumarasi = p.OdaNumarasi,
            }).ToList();

        }



    }


    public class OgrenciTip
    {
        public int OgrenciID { get; set; }
        public string AdSoyad { get; set; }
        public string TC { get; set; }
        public System.DateTime DogumTarihi { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string AcilDurumTelefon { get; set; }
        public string VeliAdSoyad { get; set; }
        public string OdaNumarasi { get; set; }
        public string Sifre { get; set; }
    }
}