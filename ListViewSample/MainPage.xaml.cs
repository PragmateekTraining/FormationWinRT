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
                return Assets.Assets.Fruits.GroupBy(f => f[0]);
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = this;

            fruitsGroupedByFirstLetter.Source = FruitsGroupedByFirstLetter;
        }
    }
}
