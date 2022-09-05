using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WPP.Web.Models
{
    public class UploadedFile
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
