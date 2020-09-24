using System;
using Xamarin.Forms;

namespace XFDraw
{
    public class SketchView: View, ISketchController
    {
        public event EventHandler SketchUpdated;

        public static readonly BindableProperty InkColorProperty =
            BindableProperty.Create(
                "InkColor",
                typeof(Color),
                typeof(SketchView),
                Color.Blue);

        public Color InkColor
        {
            get { return (Color)GetValue(InkColorProperty); }
            set { SetValue(InkColorProperty, value); }
        }

        public void Clear()
        {
            MessagingCenter.Send(this, "Clear");
        }

        void ISketchController.SendSketchUpdated()
        {
            if (SketchUpdated != null)
            {
                SketchUpdated(this, EventArgs.Empty);
            }
        }
    }
}
