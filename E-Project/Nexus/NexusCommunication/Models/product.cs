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
    using System.ComponentModel.DataAnnotations;

    public partial class product
    {
        public int id { get; set; }
        public int vendor_id { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public int price { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public int quantity { get; set; }
        public Nullable<int> total { get; set; }
    
        public virtual vendor vendor { get; set; }
    }
}
