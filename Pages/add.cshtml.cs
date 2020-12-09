using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;

namespace aspnetcoreapp.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Movie MovieVM { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private readonly MovieDBContext DbContext;

        public AddModel(ILogger<IndexModel> logger,MovieDBContext dbcontext)
        {
            _logger = logger;
            DbContext = dbcontext;            
        }

        public void OnGet()
        {
                
        }

         public ActionResult OnPost()
        {
            var movie = MovieVM;
            if (!ModelState.IsValid)
            {
                return Page(); // return page
            }

            movie.ID = 0;
            var result = DbContext.Add(movie);
            DbContext.SaveChanges(); // Saving Data in database

            return RedirectToPage("index");

        }
    

        
    }
}