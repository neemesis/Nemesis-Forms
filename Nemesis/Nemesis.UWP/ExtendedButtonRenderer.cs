using Nemesis;
using Nemesis.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

[assembly: ExportRenderer(typeof(ExtendedButton), typeof(ExtendedButtonRenderer))]
namespace Nemesis.UWP {
    public class ExtendedButtonRenderer : ButtonRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                e.NewElement.Text = "BJLKSJDFLSKDJFSLKFJdlk";
            }

            if (e.OldElement != null) {

            }

            if (Control != null) {
                
            }
        }
    }
}
