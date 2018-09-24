using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LHBOL
{
    [Table("LHUser")]
    public class LHUser:IdentityUser
    {
        //[Key]
        //public string Id { get; set; }
        //public string UserEmail { get; set; }
        //public string Name { get; set; }

        public string Contact { get; set; }

        //public string Password { get; set; }

        public IEnumerable<LHUrl> LHUrl { get; set; }

    }
}
