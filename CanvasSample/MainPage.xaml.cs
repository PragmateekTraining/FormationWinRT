using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CanvasSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void InsertSymbol(Canvas canvas, Point position)
        {
            TextBlock tb = new TextBlock { Text = "*", FontSize = 30 };

            tb.SetValue(Canvas.LeftProperty, position.X);
            tb.SetValue(Canvas.TopProperty, position.Y);

            canvas.Children.Add(tb);
        }

        private void Canvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InsertSymbol((Canvas)sender, e.GetPosition((Canvas)sender));
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            InsertSymbol((Canvas)sender, e.GetCurrentPoint((Canvas)sender).Position);
        }
    }
}
