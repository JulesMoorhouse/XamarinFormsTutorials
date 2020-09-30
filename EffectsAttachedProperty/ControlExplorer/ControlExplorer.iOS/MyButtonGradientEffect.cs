using System;
using System.ComponentModel;
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

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Xamarin.Forms.Button == false)
            {
                return;
            }

            if (e.PropertyName == ButtonGradientEffect.GradientColorProperty.PropertyName
                 || e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName
                 || e.PropertyName == VisualElement.WidthProperty.PropertyName
                 || e.PropertyName == VisualElement.HeightProperty.PropertyName)
            {
                SetGradient();
            }
        }

        void SetGradient()
        {
            gradLayer?.RemoveFromSuperLayer();

            var xfButton = Element as Button;
            var colourTop = xfButton.BackgroundColor;
            var colourBottom = ButtonGradientEffect.GetGradientColor(xfButton);

            gradLayer = Gradient.GetGradientLayer(
                colourTop.ToCGColor(),
                colourBottom.ToCGColor(),
                (float)xfButton.Width,
                (float)xfButton.Height);

            Control.Layer.InsertSublayer(gradLayer, 0);
        }
    }
}
