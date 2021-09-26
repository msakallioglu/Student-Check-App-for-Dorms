using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OgrenciYurduApi.Controllers
{
    public class PersonelController:ApiController
    {
        OgrenciYurduEntities _ent = new OgrenciYurduEntities();
        [HttpGet]
        public List<PersonelTip> TumPersonelleriGetir()
        {
            return _ent.Personel.Select(p => new PersonelTip()
            {
                PersonelID = p.PersonelID,
                AdSoyad = p.AdSoyad,
                Telefon = p.Telefon,
            }).ToList();

        }
        [HttpGet]
        public List<PersonelTip> PersonelAra(string kelime)
        {
           return _ent.Personel.Where(p => p.AdSoyad.Contains(kelime)). Select(p => new PersonelTip()
               {
                   PersonelID = p.PersonelID,
                   AdSoyad = p.AdSoyad,                
                   Telefon = p.Telefon,         
               }).ToList();

        }

        [HttpPost]
        public bool PersonelEkle(Personel veri)
        {
            try
            {
                _ent.Personel.Add(veri);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




    }
    public class PersonelTip
    {

        public int PersonelID { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }


    }
}