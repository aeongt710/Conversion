using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conversion.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [Required]
        [BindProperty]
        public string Input { get; set; }
        [BindProperty]
        public string Output { get; set; }

        public void  OnGet(string fromBase, string toBase, string Number)
        {
            if (Number != null)
            {
                int v1 = Int16.Parse(fromBase);
                int v2 = Int16.Parse(toBase);
                Output = Convert.ToString(Convert.ToInt32(Number, v1), v2);
                //Console.WriteLine("Answer iss " + result);
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var select1 = Request.Form["Select_fromBase"];
            var select2 = Request.Form["Select_toBase"];
            return RedirectToAction("", new { fromBase = select1, toBase = select2, Number = Input });

        }
    }
}
