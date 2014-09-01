using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SettingsFlyoutSample
{
    public class Settings : NotifyPropertyChangedBase
    {
        private double x;
        public double X
        {
            get { return x; }
            set { UpdateAndNotify(ref x, value); }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { UpdateAndNotify(ref y, value); }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { UpdateAndNotify(ref color, value); }
        }
    }
}
