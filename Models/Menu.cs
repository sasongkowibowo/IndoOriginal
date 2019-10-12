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

    public partial class Menu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter menu type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter menu name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter menu description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter calories")]
        public int Calories { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string ImagePath { get; set; }
    }
}
