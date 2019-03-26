using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }
    
        public IList<Movie> Movie { get;set; }
        
        //BindProperty binds form values and query strings with the same name as the property
        [BindProperty(SupportsGet = true)]
        
        //SearchString contains the text user enter in search text box
        public string SearchString {get; set;}
        
        //Genres contains the list of genres
        public SelectList Genres {get;set;}

        [BindProperty(SupportsGet = true)]

        //MovieGenre contains the specific genre the user selects (for example "Comedy")
        public string MovieGenre {get; set;}
        public async Task OnGetAsync()
        {
            //Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            //Creating LINQ query to select the movies
            var movies = from m in _context.Movie
                         select m;
            //
            if (!string.IsNullOrEmpty(SearchString))
            {
                //Contains maps to "SQL LIKE", in SQLite it's case sensitive
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                //retrives all the genres from database
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            //SelectList of genres is created by projecting the distinc genres
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());  
            Movie = await movies.ToListAsync();
        }
    }
}