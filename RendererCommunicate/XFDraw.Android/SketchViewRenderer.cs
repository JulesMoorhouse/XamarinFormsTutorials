using System;
using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFDraw;
using XFDraw.Droid;

[assembly: ExportRenderer(typeof(SketchView), typeof(SketchViewRenderer))]
namespace XFDraw.Droid
{
    class SketchViewRenderer : ViewRenderer<SketchView, PaintView>
    {
        public SketchViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SketchView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var paintView = new PaintView(Android.App.Application.Context);
                paintView.SetInkColor(this.Element.InkColor.ToAndroid());
                SetNativeControl(paintView);

                MessagingCenter.Subscribe<SketchView>(this, "Clear", OnMessageClear);
                paintView.LineDrawn += PaintViewLineDrawn;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == SketchView.InkColorProperty.PropertyName)
            {
                Control.SetInkColor(this.Element.InkColor.ToAndroid());
            }
        }

        void OnMessageClear(SketchView sender)
        {
            if (sender == Element)
            {
                Control.Clear();
            }
        }

        private void PaintViewLineDrawn(object sender, EventArgs e)
        {
            var sketchCon = (ISketchController)Element;

            if (sketchCon == null)
            {
                return;
            }

            sketchCon.SendSketchUpdated();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MessagingCenter.Unsubscribe<SketchView>(this, "Clear");
            }

            base.Dispose(disposing);
        }
    }
}
