//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoStudio.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_TitleRef
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_TitleRef()
        {
            this.tbl_customer = new HashSet<tbl_customer>();
        }
    
        public string Code { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string CIFRef { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_customer> tbl_customer { get; set; }
    }
}
