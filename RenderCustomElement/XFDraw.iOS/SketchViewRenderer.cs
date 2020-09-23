using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFDraw;
using XFDraw.iOS;

[assembly: ExportRenderer(typeof(SketchView), typeof(SketchViewRenderer))]
namespace XFDraw.iOS
{
    class SketchViewRenderer : ViewRenderer<SketchView, PaintView>
    {
        public SketchViewRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SketchView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var paintView = new PaintView();
                paintView.SetInkColor(this.Element.InkColor.ToUIColor());
                SetNativeControl(paintView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SketchView.InkColorProperty.PropertyName)
            {
                Control.SetInkColor(this.Element.InkColor.ToUIColor());
            }
        }
    }
}
