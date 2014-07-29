using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LocalFolderSample
{
    public sealed partial class DataFileView : UserControl
    {
        public DataFileViewModel Model
        {
            get { return (DataFileViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(DataFileViewModel), typeof(DataFileView), null);

        public DataFileView()
        {
            this.InitializeComponent();

            root.DataContext = this;
        }
    }
}
