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
    
    public partial class Ogrenci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogrenci()
        {
            this.OgrenciIzin = new HashSet<OgrenciIzin>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciIzin> OgrenciIzin { get; set; }
    }
}
