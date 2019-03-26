using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    ///Seeding the DB using Dependency Injection
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
                    {
                        //Look for any movies if there are any movies in the DB, the seed initializer returns 
                        //and no movies are added
                        if(context.Movie.Any())
                        {    
                            return; //DB has been seeded
                        }
                        //Creating new records by creating Movie objects
                        context.Movie.AddRange(
                            new Movie
                            {
                                Title = "When Harry Met Sally",
                                ReleaseDate = DateTime.Parse("1989-2-12"),
                                Genre = "Romantic Comedy",
                                Price = 7.99M,
                                Rating = "R"
                            },

                            new Movie
                            {
                                Title = "Ghostbusters",
                                ReleaseDate = DateTime.Parse("1984-3-13"),
                                Genre = "Comedy",
                                Price = 8.99M,
                                Rating = "G"
                            },      

                            new Movie
                            {
                                Title = "Ghostbusters 2",
                                ReleaseDate = DateTime.Parse("1986-2-23"),
                                Genre = "Comedy",
                                Price = 9.99M,
                                Rating = "R"
                            },      

                            new Movie
                            {
                                Title = "Rio Bravo",
                                ReleaseDate = DateTime.Parse("1959-4-15"),
                                Genre = "Western",
                                Price = 3.99M,
                                Rating = "NA"
                            }
                        );
                        context.SaveChanges();     
                    }
        }
    }
}