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
    public class EditModel : PageModel
    {
        [BindProperty]
        public Movie MovieVM { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private readonly MovieDBContext DbContext;

        public EditModel(ILogger<IndexModel> logger,MovieDBContext dbcontext)
        {
            _logger = logger;
            DbContext = dbcontext;            
        }

        public void OnGet(int? id)
        {
                 Movie myMovie = (from m in DbContext.Movies
                                 where m.ID ==id
                                 select m).Take(1).ToList()[0];
                MovieVM = myMovie;
        }

         public ActionResult OnPost()
        {
            var movie = MovieVM;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DbContext.Entry(movie).Property(x => x.Title).IsModified = true;
            DbContext.Entry(movie).Property(x => x.ReleaseDate).IsModified = true;
            DbContext.Entry(movie).Property(x => x.Price).IsModified = true;
            DbContext.Entry(movie).Property(x => x.Genre).IsModified = true;
            DbContext.Entry(movie).Property(x => x.ReleaseDate).IsModified = true;
            DbContext.SaveChanges();
            return RedirectToPage("index");
        }
    

        
    }
}