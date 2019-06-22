//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminAccountCreation
{
    using System;
    using System.Collections.Generic;
    
    public partial class IdentificationCardType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IdentificationCardType()
        {
            this.CheckReleases = new HashSet<CheckRelease>();
            this.CustomerIdentificationCards = new HashSet<CustomerIdentificationCard>();
        }
    
        public int IdentificationCardTypeID { get; set; }
        public string CardType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckRelease> CheckReleases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerIdentificationCard> CustomerIdentificationCards { get; set; }
    }
}
