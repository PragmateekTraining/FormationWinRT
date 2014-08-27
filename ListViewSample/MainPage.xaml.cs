using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace ListViewSample
{
    public sealed partial class MainPage : Page
    {
        public IEnumerable<string> Fruits
        {
            get
            {
                return Assets.Assets.Fruits;
            }
        }

        public IEnumerable<IGrouping<char, string>> FruitsGroupedByFirstLetter
        {
            get
            {
                return Fruits.GroupBy(f => f[0]);
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = this;

            fruitsGroupedByFirstLetter.Source = FruitsGroupedByFirstLetter;
            fruitsGroupedByFirstLetterCustom.Source = Fruits.GroupBy(f => f[0]).Select(g => new { Letter = g.Key, Fruits = g });
        }
    }
}
