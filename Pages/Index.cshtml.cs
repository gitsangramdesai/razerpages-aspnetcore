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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MovieDBContext DbContext;

        public static List<Movie> myMovies= new List<Movie>();

        public Movie My= new Movie();

        public IndexModel(ILogger<IndexModel> logger,MovieDBContext db)
        {
            _logger = logger;
            this.DbContext = db;

            IndexModel.myMovies = (from m in DbContext.Movies
                           select m).ToList();
        }

        public void OnGet()
        {

        }
    
        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var movie = (from m in DbContext.Movies
                            where m.ID == id
                            select m).SingleOrDefault();

                DbContext.Remove(movie);
                DbContext.SaveChanges();
            }
            return RedirectToPage("index");
        }

    }
}
