using System.Windows;
using System.Windows.Controls;

namespace VNEditor.MVVM.View
{
    public class BasicCanvas : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            return base.ArrangeOverride(arrangeSize);
        }
    }
}
