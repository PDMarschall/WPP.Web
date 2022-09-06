using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WPP.Domain.Datastructures;
using WPP.Domain.Models;
using WPP.Infrastructure;
using WPP.Web.Models;

namespace WPP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PasswordValidationParser _parser;

        [BindProperty]
        public PasswordCollection SubmittedPasswords { get; set; }

        public HomeController(ILogger<HomeController> logger, PasswordValidationParser parser)
        {
            _logger = logger;
            _parser = parser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFile(SubmittedFile file)
        {
            ProcessFile(file);
            ViewBag.ValidPasswords = SubmittedPasswords.ReturnValidPasswords();
            ViewBag.InvalidPasswords = SubmittedPasswords.ReturnInvalidPasswords();
            return View();
        }

        public IActionResult Reklame()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ProcessFile(SubmittedFile submittedFile)
        {
            IEnumerable<string> content = _parser.ReadPasswordFile(submittedFile.Content.OpenReadStream());
            SubmittedPasswords = _parser.ParsePasswordPolicyFile(content);
            SubmittedPasswords.SetValidationPolicy(new ValidationPolicy_One());
            SubmittedPasswords.ValidateCollection();
        }
    }
}