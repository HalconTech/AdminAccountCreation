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
    
    public partial class CheckRelease
    {
        public int CheckReleaseID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<System.DateTime> ReleasedDate { get; set; }
        public byte[] DateTimeStamp { get; set; }
        public Nullable<int> CheckID { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> ReleasedBy { get; set; }
        public byte[] DigitalSignature { get; set; }
        public Nullable<int> IdentificationCardTypeID { get; set; }
        public string IdentificationCardNumber { get; set; }
    
        public virtual Check Check { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual IdentificationCardType IdentificationCardType { get; set; }
    }
}
