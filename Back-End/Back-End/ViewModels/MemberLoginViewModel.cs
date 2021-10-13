using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class MemberLoginViewModel
    {

        [StringLength(maximumLength: 20, MinimumLength = 6)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
