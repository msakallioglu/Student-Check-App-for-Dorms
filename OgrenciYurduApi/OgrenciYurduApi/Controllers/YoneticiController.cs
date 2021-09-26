using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OgrenciYurduApi.Controllers
{
    public class YoneticiController: ApiController
    {
        OgrenciYurduEntities _ent = new OgrenciYurduEntities();

        [HttpGet]
        public int YoneticiGirisYap(string TC, string sifre)
        {
            Yonetici y= _ent.Yonetici.FirstOrDefault(p => p.TC == TC && p.Sifre == sifre);
            if (y == null)
            {
                return 0;
            }
            else
                return y.YoneticiID;
        }

        [HttpGet]
        public List<YoneticiTip> TumYoneticileriGetir()
        {
            return _ent.Yonetici.Select(p => new YoneticiTip()
            {
                YoneticiID=p.YoneticiID,
                AdSoyad = p.AdSoyad,
                TC = p.TC,
                Telefon = p.Telefon,
                Sifre = p.Sifre,
            }).ToList();

        }

        [HttpGet]
        public List<YoneticiTip> IdyeGoreYoneticiGetir(int YoneticiID)
        {
            return _ent.Yonetici.Where(p => p.YoneticiID == YoneticiID).
               Select(p => new YoneticiTip()
               {
                   YoneticiID = p.YoneticiID,
                   AdSoyad = p.AdSoyad,
                   Telefon = p.Telefon,
                   TC = p.TC,
                   Sifre = p.Sifre,
               }).ToList();
        }
    }
    public class YoneticiTip
    {
        public int YoneticiID { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string TC { get; set; }
        public string Sifre { get; set; }

    }
}