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
    
    public partial class SecurityQuestionUser
    {
        public int SecurityQuestionUserID { get; set; }
        public Nullable<int> SecurityQuestionID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Answer { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SecurityQuestionBank SecurityQuestionBank { get; set; }
    }
}