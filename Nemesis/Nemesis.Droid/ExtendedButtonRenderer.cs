using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Nemesis;
using Nemesis.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace Nemesis.Droid {
    public class ExtendedButtonRenderer : ButtonRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {

            }

            if (e.OldElement != null) {

            }

            if (Control != null) {
                var GradientDrawable = new GradientDrawable();
                GradientDrawable.SetShape(ShapeType.Rectangle);
                GradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
                GradientDrawable.SetStroke(4, Element.BorderColor.ToAndroid());
                GradientDrawable.SetCornerRadius(38.0f);

                Control.SetBackground(GradientDrawable);
            }
        }
    }
}