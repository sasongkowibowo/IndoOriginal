//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndoOriginal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter valid telephone number")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please choose a branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        public string LoginId { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}