using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DataBindingSample
{
    public class SpreadConverter : IValueConverter
    {
        public int Max { get; set; }

        public SpreadConverter()
        {
            Max = -1;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int? reference = parameter != null ? System.Convert.ToInt32(parameter) :
                             Max != -1 ? Max :
                             null as int?;

            if (reference == null)
                return DependencyProperty.UnsetValue;

            return reference - System.Convert.ToInt64(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
