using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OgrenciYurduApi.Controllers
{
    public class PersonelGorevController : ApiController
    {
        OgrenciYurduEntities _ent = new OgrenciYurduEntities();
        [HttpGet]
        public List<PersonelGorevTip> TumGorevleriGetir()
        {
            return _ent.PersonelGorev.Select(p => new PersonelGorevTip()
            {
                GorevID = p.GorevID,
                PersonelID = p.PersonelID,
                PersonelAdSoyad = p.Personel.AdSoyad,
                GorevAciklama = p.GorevAciklama,
                GoreviAtayanYoneticiAdSoyad = p.Yonetici.AdSoyad,
                YoneticiID = p.YoneticiID,
            }).ToList();

        }
        [HttpPost]
        public bool GorevEkle(PersonelGorev veri)
        {
            try
            {
                _ent.PersonelGorev.Add(veri);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public List<PersonelGorevTip> GorevSil(int GorevID)
        {
            PersonelGorev pg = _ent.PersonelGorev.Find(GorevID);
            if (pg != null)
            {
                _ent.PersonelGorev.Remove(pg);
                _ent.SaveChanges();
                return TumGorevleriGetir();
            }
            else
                return TumGorevleriGetir();
        }


    } 
    public class PersonelGorevTip
    {
        public int GorevID { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public int YoneticiID { get; set; }
        public string GorevAciklama { get; set; }
        public string PersonelAdSoyad { get; set; }
        public string GoreviAtayanYoneticiAdSoyad { get; set; }
 
    }
}