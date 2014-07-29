using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ListViewSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public IEnumerable<string> Fruits
        {
            get
            {
                return new[]
                {
                    "Apple",
"Apricot",
"Avocado",
"Banana",
"Breadfruit",
"Bilberry",
"Blackberry",
"Blackcurrant",
"Blueberry",
"Boysenberry",
"Cantaloupe",
"Currant",
"Cherry",
"Cherimoya",
"Cloudberry",
"Coconut",
"Cranberry",
"Cucumber",
"Damson",
"Date",
"Dragonfruit",
"Durian",
"Eggplant",
"Elderberry",
"Feijoa",
"Fig",
"Goji berry",
"Gooseberry",
"Grape",
"Raisin",
"Grapefruit",
"Guava",
"Huckleberry",
"Honeydew",
"Jackfruit",
"Jambul",
"Jujube",
"Kiwi fruit",
"Kumquat",
"Lemon",
"Lime",
"Loquat",
"Lychee",
"Mango",
"Marion berry",
"Melon",
"Cantaloupe",
"Honeydew",
"Watermelon",
"Rock melon",
"Miracle fruit",
"Mulberry",
"Nectarine",
"Nut",
"Olive",
"Orange",
"Clementine",
"Mandarine",
"Blood Orange",
"Tangerine",
"Papaya",
"Passionfruit",
"Peach",
"Pepper",
"Pear",
"Persimmon",
"Physalis",
"Plum",
"Pineapple",
"Pomegranate",
"Pomelo",
"Purple Mangosteen",
"Quince",
"Raspberry",
"Rambutan",
"Redcurrant",
"Salal berry",
"Salmon berry",
"Satsuma",
"Star fruit",
"Strawberry",
"Tamarillo",
"Tomato",
"Ugli",
"Watermelon"
                };
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = this;
        }
    }
}
