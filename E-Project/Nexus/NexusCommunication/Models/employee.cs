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

    public partial class employee
    {
        public int id { get; set; }
        
        public int store_id { get; set; }
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "This feild is required")]
        public string name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This feild is required")]
        public string email { get; set; }
        [StringLength(10, ErrorMessage = "Min 3 & Max 10 characters allowed", MinimumLength = 3)]
        [Required(ErrorMessage = "This feild is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string address { get; set; }
    
        public virtual store store { get; set; }
    }
}
