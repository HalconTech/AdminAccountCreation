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
    
    public partial class ControlNumber
    {
        public int ControlNoID { get; set; }
        public Nullable<int> FundBankID { get; set; }
        public Nullable<int> NextControlNo { get; set; }
        public Nullable<int> BeginingControlNo { get; set; }
        public Nullable<int> EndingControlNo { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual FundBank FundBank { get; set; }
    }
}
