using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
