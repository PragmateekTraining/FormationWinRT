using System.Collections.ObjectModel;
using Model;

namespace DataViewsSample
{
    public class MainPageViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }

        public MainPageViewModel()
        {
            this.Movies = new ObservableCollection<Movie>(MoviesRepository.GetAllMovies());
        }
    }
}
