using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TreeViewSample
{
    public sealed partial class CommentView : UserControl
    {
        public Comment Comment
        {
            get { return (Comment)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(Comment), typeof(CommentView), new PropertyMetadata(null));        

        public CommentView()
        {
            this.InitializeComponent();

            root.DataContext = this;
        }
    }
}
