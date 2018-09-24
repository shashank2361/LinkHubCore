using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LHUI.ViewModels
{
    public class CreateUrlViewModel
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Display(Name ="Url")]
        public string LHUrlName { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
