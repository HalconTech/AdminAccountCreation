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
    
    public partial class Payee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payee()
        {
            this.Disbursements = new HashSet<Disbursement>();
            this.PayeeRepresentatives = new HashSet<PayeeRepresentative>();
        }
    
        public int PayeeID { get; set; }
        public string PayeeNo { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string TIN { get; set; }
        public string LandlineNo { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement> Disbursements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayeeRepresentative> PayeeRepresentatives { get; set; }
    }
}
