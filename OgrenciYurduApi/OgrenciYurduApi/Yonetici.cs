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
    
    public partial class Yonetici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yonetici()
        {
            this.PersonelGorev = new HashSet<PersonelGorev>();
            this.OgrenciIzin = new HashSet<OgrenciIzin>();
        }
    
        public int YoneticiID { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string TC { get; set; }
        public string Sifre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonelGorev> PersonelGorev { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciIzin> OgrenciIzin { get; set; }
    }
}
