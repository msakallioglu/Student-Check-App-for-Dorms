//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciYurduApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class OgrenciIzin
    {
        public int IzinID { get; set; }
        public int OgrenciID { get; set; }
        public Nullable<int> YoneticiID { get; set; }
        public Nullable<int> IzinOnayDurumu { get; set; }
        public System.DateTime IzinIstenildigiTarih { get; set; }
        public string IzinAciklama { get; set; }
    
        public virtual Ogrenci Ogrenci { get; set; }
        public virtual Yonetici Yonetici { get; set; }
    }
}
