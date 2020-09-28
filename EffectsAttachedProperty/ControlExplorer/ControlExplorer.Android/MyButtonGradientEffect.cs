using System;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ControlExplorer.Droid
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;

        public MyButtonGradientEffect()
        {
        }

        protected override void OnAttached()
        {
            if (Element is Xamarin.Forms.Button == false)
            {
                return;
            }

            oldDrawable = Control.Background;

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (oldDrawable != null)
            {
                Control.Background = oldDrawable;
            }
        }

        void SetGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colourTop = xfButton.BackgroundColor;
            var colourBottom = Xamarin.Forms.Color.Black;

            var drawable = Gradient.GetGradientDrawable(colourTop.ToAndroid(), colourBottom.ToAndroid());

            Control.SetBackground(drawable);
        }
    }
}
