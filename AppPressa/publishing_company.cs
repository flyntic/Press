//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppPressa
{
    using System;
    using System.Collections.Generic;
    
    public partial class publishing_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public publishing_company()
        {
            this.All_Publications = new HashSet<All_Publications>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string legal_address { get; set; }
        public string description { get; set; }
        public string phone { get; set; }
        public string director { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<All_Publications> All_Publications { get; set; }
    }
}
