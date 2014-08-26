using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
