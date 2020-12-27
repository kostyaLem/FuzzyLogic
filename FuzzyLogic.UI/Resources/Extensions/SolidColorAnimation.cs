using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FuzzyLogic.UI.Resources.Extensions
{
    public class SolidColorAnimation : ColorAnimation
    {
        public SolidColorBrush ToBrush
        {
            get { return To == null ? null : new SolidColorBrush(To.Value); }
            set { To = value?.Color; }
        }
    }
}
