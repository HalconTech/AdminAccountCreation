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
    
    public partial class LicensingCode
    {
        public string LicenseKey { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string MachineName { get; set; }
        public Nullable<bool> IsDemo { get; set; }
        public Nullable<int> SubModuleID { get; set; }
        public Nullable<int> UserID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SubModule SubModule { get; set; }
    }
}
