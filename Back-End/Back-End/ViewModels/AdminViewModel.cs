﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class AdminViewModel
    {
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }

        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
