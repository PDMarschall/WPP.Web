using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WPP.Web.Models
{
    public class SubmittedFile
    {
        [Required]
        public IFormFile Content { get; set; }
        public string PolicyID { get; set; }
    }
}
