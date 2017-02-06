using Nemesis;
using Nemesis.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace Nemesis.iOS {
    public class ExtendedButtonRenderer : ButtonRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {

            }

            if (e.OldElement != null) {

            }

            if (Control != null) {
                Control.Layer.CornerRadius = 22;
                Control.ClipsToBounds = true;
            }
        }
    }
}