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
    
    public partial class BankTrail
    {
        public int BankTrailID { get; set; }
        public string DebitCredit { get; set; }
        public Nullable<int> FundBankID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string EntryName { get; set; }
        public Nullable<int> CheckID { get; set; }
        public Nullable<int> EntryNameID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Check Check { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FundBank FundBank { get; set; }
    }
}
