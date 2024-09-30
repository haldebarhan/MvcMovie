using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
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
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                },
                  new Movie
                  {
                      Title = "The Outpost",
                      ReleaseDate = DateTime.Parse("2020-7-3"),
                      Genre = "War",
                      Price = 5M
                  },
                  new Movie
                  {
                      Title = "Act of Valor",
                      ReleaseDate = DateTime.Parse("2012-2-24"),
                      Genre = "War",
                      Price = 13M
                  },
                  new Movie
                  {
                      Title = "Accepted",
                      ReleaseDate = DateTime.Parse("2006-8-18"),
                      Genre = "Comedy",
                      Price = 23M
                  }
            );
            context.SaveChanges();
        }
    }
}