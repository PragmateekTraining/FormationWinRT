using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticZoomSample
{
    public class ActorMovies
    {
        public Actor Actor { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }

    public class MainPageViewModel
    {
        public IEnumerable<ActorMovies> MoviesGroupedByActors { get; set; }

        public MainPageViewModel()
        {
            IEnumerable<Movie> movies = MoviesRepository.GetAllMovies();
            IEnumerable<Actor> actors = movies.SelectMany(m => m.Actors).Distinct();

            MoviesGroupedByActors = actors.Select(a => new ActorMovies
                                                       {
                                                           Actor = a,
                                                           Movies = movies.Where(m => m.Actors.Contains(a)).Select(m => new Movie {  Title = m.Title, PosterURI = m.PosterURI })
                                                       });
        }
    }
}
