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
    public class DetailModel : PageModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly MovieDBContext DbContext;

        public DetailModel(ILogger<IndexModel> logger,MovieDBContext db)
        {
            _logger = logger;
            this.DbContext = db;            
        }

        public void OnGet(int? id)
        {
            Movie myMovie = (from m in DbContext.Movies
                            where m.ID == id
                           select m).Take(1).ToList()[0];
            ID = myMovie.ID;
            Title = myMovie.Title;
            ReleaseDate = myMovie.ReleaseDate;
            Genre = myMovie.Genre;
            Price = myMovie.Price;    
        }
    }
}
