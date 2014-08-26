using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewsSample
{
    public class MoviesRepository
    {
        public static IEnumerable<Movie> GetAllMovies()
        {
            return new[]
            {
                new Movie{ Title = "Die Hard", PosterURI = "/Assets/MoviesDB/Posters/DieHard.jpg" },
                new Movie{ Title = "Die Hard 2", PosterURI = "/Assets/MoviesDB/Posters/DieHard2.jpg" },
                new Movie{ Title = "Die Hard 3", PosterURI = "/Assets/MoviesDB/Posters/DieHard3.jpg" },
                new Movie{ Title = "Die Hard 4", PosterURI = "/Assets/MoviesDB/Posters/DieHard4.jpg" },
                new Movie{ Title = "Die Hard 5", PosterURI = "/Assets/MoviesDB/Posters/DieHard5.jpg" }
            };
        }
    }
}
