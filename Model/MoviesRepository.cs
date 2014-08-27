using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MoviesRepository
    {
        public static IEnumerable<Movie> GetAllMovies()
        {
            Actor MelGibson = new Actor { FirstName = "Mel", LastName = "Gibson", PhotoURI = "/Assets/MoviesDB/Actors/MelGibson.jpg" };
            Actor SylvesterStallone = new Actor { FirstName = "Sylvester", LastName = "Stallone", PhotoURI = "/Assets/MoviesDB/Actors/SylvesterStallone.jpg" };
            Actor BruceWillis = new Actor { FirstName = "Bruce", LastName = "Willis", PhotoURI = "/Assets/MoviesDB/Actors/BruceWillis.jpg" };

            return new[]
            {
                new Movie{ Title = "Die Hard", PosterURI = "/Assets/MoviesDB/Posters/DieHard.jpg", Actors = new []{ BruceWillis } },
                new Movie{ Title = "Die Hard 2", PosterURI = "/Assets/MoviesDB/Posters/DieHard2.jpg", Actors = new []{ BruceWillis } },
                new Movie{ Title = "Die Hard 3", PosterURI = "/Assets/MoviesDB/Posters/DieHard3.jpg", Actors = new []{ BruceWillis } },
                new Movie{ Title = "Die Hard 4", PosterURI = "/Assets/MoviesDB/Posters/DieHard4.jpg", Actors = new []{ BruceWillis } },
                new Movie{ Title = "Die Hard 5", PosterURI = "/Assets/MoviesDB/Posters/DieHard5.jpg", Actors = new []{ BruceWillis } },
                new Movie{ Title = "Lethal Weapon", PosterURI = "/Assets/MoviesDB/Posters/LethalWeapon.jpg", Actors = new []{ MelGibson } },
                new Movie{ Title = "Lethal Weapon 2", PosterURI = "/Assets/MoviesDB/Posters/LethalWeapon2.jpg", Actors = new []{ MelGibson } },
                new Movie{ Title = "Lethal Weapon 3", PosterURI = "/Assets/MoviesDB/Posters/LethalWeapon3.jpg", Actors = new []{ MelGibson } },
                new Movie{ Title = "Lethal Weapon 4", PosterURI = "/Assets/MoviesDB/Posters/LethalWeapon4.jpg", Actors = new []{ MelGibson } },
                new Movie{ Title = "The Expendables", PosterURI = "/Assets/MoviesDB/Posters/TheExpendables.jpg", Actors = new[]{ SylvesterStallone, BruceWillis } },
                new Movie{ Title = "The Expendables 2", PosterURI = "/Assets/MoviesDB/Posters/TheExpendables2.jpg", Actors = new[]{ SylvesterStallone, BruceWillis } },
                new Movie{ Title = "The Expendables 3", PosterURI = "/Assets/MoviesDB/Posters/TheExpendables3.jpg", Actors = new[]{ SylvesterStallone, MelGibson } },
                new Movie{ Title = "The Sixth Sense", PosterURI = "/Assets/MoviesDB/Posters/TheSixthSense.jpg", Actors = new[]{ BruceWillis }  }
            };
        }
    }
}
