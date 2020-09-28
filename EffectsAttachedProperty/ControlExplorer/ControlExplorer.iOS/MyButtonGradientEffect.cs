using System;
using CoreAnimation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ControlExplorer.iOS
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        CAGradientLayer gradLayer;

        protected override void OnAttached()
        {
            if (Element is Button == false)
            {
                return;
            }

            SetGradient();
        }

        protected override void OnDetached()
        {
            if (gradLayer != null)
            {
                gradLayer.RemoveFromSuperLayer();
            }
        }

        void SetGradient()
        {
            gradLayer?.RemoveFromSuperLayer();

            var xfButton = Element as Button;
            var colourTop = xfButton.BackgroundColor;
            var colourBottom = Color.Black;

            gradLayer = Gradient.GetGradientLayer(
                colourTop.ToCGColor(),
                colourBottom.ToCGColor(),
                (float)xfButton.Width,
                (float)xfButton.Height);

            Control.Layer.InsertSublayer(gradLayer, 0);
        }
    }
}
