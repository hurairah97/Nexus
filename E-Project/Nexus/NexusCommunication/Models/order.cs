//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NexusCommunication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        public int id { get; set; }
        public string code { get; set; }
        public int customer_id { get; set; }
        public int plans_id { get; set; }
        public Nullable<int> hourly_basis_id { get; set; }
        public Nullable<int> unlimited_id { get; set; }
        public Nullable<int> landline_plans_id { get; set; }
        public string customer_s_feedback { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual hourly hourly { get; set; }
        public virtual planbb planbb { get; set; }
        public virtual plan plan { get; set; }
        public virtual unlimite unlimite { get; set; }
    }
}