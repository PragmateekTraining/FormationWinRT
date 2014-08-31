using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SearchSample
{
    public class SearchManager
    {
        public static void Search(string text, SearchSuggestionCollection suggestions)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            
            IEnumerable<Movie> matchingMovies = MoviesRepository.Movies.Where(movie => (" " + movie.Title).IndexOf(" " + text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                                                                       .Take(10);
            IEnumerable<Actor> matchingActors = MoviesRepository.Actors.Where(actor => actor.FirstName.StartsWith(text, StringComparison.CurrentCultureIgnoreCase) || actor.LastName.StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
                                                                       .Take(10);

            if (matchingMovies.Any())
            {
                suggestions.AppendSearchSeparator("Movies");
                
                foreach (Movie movie in matchingMovies)
                {
                    IRandomAccessStreamReference imageReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx://" + movie.PosterURI));

                    suggestions.AppendResultSuggestion(movie.Title, "", "movie:" + movie.Title, imageReference, "");
                }
            }

            if (matchingActors.Any())
            {
                suggestions.AppendSearchSeparator("Actors");

                foreach (Actor actor in matchingActors)
                {
                    IRandomAccessStreamReference imageReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx://" + actor.PhotoURI));

                    suggestions.AppendResultSuggestion(actor.FullName, "", "actor:" + actor.FullName, imageReference, "");
                }
            }
        }

        public static void NavigateToResult(Frame frame, string tag)
        {
            Type pageType = null;
            object parameter = null;

            if (tag.StartsWith("movie:"))
            {
                pageType = typeof(MoviePage);
                parameter = MoviesRepository.Movies.Single(movie => movie.Title.Equals(tag.Substring("movie:".Length)));
            }
            else if (tag.StartsWith("actor:"))
            {
                pageType = typeof(ActorPage);
                parameter = MoviesRepository.Actors.Single(actor => actor.FullName.Equals(tag.Substring("actor:".Length)));
            }

            frame.Navigate(pageType, parameter);
        }

        public static void NavigateToResultPage(Frame frame, string query)
        {
            IEnumerable<object> matchingMovies = MoviesRepository.Movies.Where(movie => movie.Title.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0);
            IEnumerable<object> matchingActors = MoviesRepository.Actors.Where(actor => actor.FullName.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0);

            IEnumerable<object> results = matchingMovies.Concat(matchingActors);

            frame.Navigate(typeof(SearchResultsPage), results);
        }
    }
}
