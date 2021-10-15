using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Email { get; set; }
    }
}
