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

    public partial class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string Number { get; set; }
        [Required(ErrorMessage = "This feild is required")]
        public string Message { get; set; }
    }
}
