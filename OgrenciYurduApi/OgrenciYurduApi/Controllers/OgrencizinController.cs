using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OgrenciYurduApi.Controllers
{
    public class OgrencizinController:ApiController
    {
        OgrenciYurduEntities _ent = new OgrenciYurduEntities();

        [HttpGet]
        public List<OgrenciIzinTip> TumOgrenciIzinleriniGetir()
        {
            return _ent.OgrenciIzin.Select(p => new OgrenciIzinTip()
            {
                IzinID = p.IzinID,
                OgrenciID = p.OgrenciID,
                YoneticiID = p.YoneticiID,
                IzinOnayDurumu = p.IzinOnayDurumu,
                IzinIstenildigiTarih =p.IzinIstenildigiTarih,
                IzinAciklama=p.IzinAciklama,
                OgrenciAdSoyad=p.Ogrenci.AdSoyad,
                YoneticiAdSoyad=p.Yonetici.AdSoyad,

            }).ToList();

        }

        [HttpGet]
        public List<OgrenciIzinTip> IdyeGoreOgrenciizinGetir(int OgrenciID)
        {
            return _ent.OgrenciIzin.Where(p => p.OgrenciID == OgrenciID).
               Select(p => new OgrenciIzinTip()
               {
                   IzinID=p.IzinID,
                   OgrenciID = p.OgrenciID,
                   IzinOnayDurumu = p.IzinOnayDurumu,
                   IzinIstenildigiTarih = p.IzinIstenildigiTarih,
                   IzinAciklama = p.IzinAciklama,
                   OgrenciAdSoyad = p.Ogrenci.AdSoyad,

               }).ToList();
        }


        [HttpPost]
        public bool IzinEkle(OgrenciIzin veri)
        {
            try
            {
                _ent.OgrenciIzin.Add(veri);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet]
        public List<OgrenciIzinTip> IzinOnayla(int IzinID, int onaydurumu,int yoneticiID)
        {

            OgrenciIzin ogrn = _ent.OgrenciIzin.Find(IzinID);
            ogrn.IzinOnayDurumu = onaydurumu;
            ogrn.YoneticiID = yoneticiID;
            _ent.SaveChanges();
            return TumOgrenciIzinleriniGetir();
            
        }

        [HttpGet]
        public List<OgrenciIzinTip> OgrenciIzinIptal(int IzinID)
        {
            OgrenciIzin o = _ent.OgrenciIzin.Find(IzinID);
            int id = o.OgrenciID;
            _ent.OgrenciIzin.Remove(o);
            _ent.SaveChanges();           
          return IdyeGoreOgrenciizinGetir(id);
        }

    }
    public class OgrenciIzinTip
    {
        public int IzinID { get; set; }
        public int OgrenciID { get; set; }
        public Nullable<int> YoneticiID { get; set; }
        public Nullable<int> IzinOnayDurumu { get; set; }
        public System.DateTime IzinIstenildigiTarih { get; set; }
        public string IzinAciklama { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string YoneticiAdSoyad { get; set; }
    }
}