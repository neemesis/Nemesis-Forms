using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nemesis;
using Nemesis.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NCheckBox), typeof(NCheckBoxRenderer))]
namespace Nemesis.Droid {
    public class NCheckBoxRenderer : ViewRenderer<NCheckBox, CheckBox> {

        protected override void OnElementChanged(ElementChangedEventArgs<NCheckBox> e) {
            base.OnElementChanged(e);

            if (this.Control == null) {
                var checkBox = new CheckBox(this.Context);
                if (Element.WidthRequest >= 0) {
                    checkBox.SetWidth((int)Element.WidthRequest);
                    checkBox.SetHeight((int)Element.WidthRequest);
                }
                checkBox.CheckedChange += CheckBoxCheckedChange;
                SetNativeControl(checkBox);
            }
            ChangeText();
            if (e.NewElement != null) {
                if (e.NewElement.WidthRequest >= 0) {
                    Control.SetHeight((int)e.NewElement.WidthRequest);
                    Control.SetWidth((int)e.NewElement.WidthRequest);
                }
                Control.Checked = e.NewElement.Checked;
                Control.Enabled = e.NewElement.IsEnabled;
            }
        }

        private void ChangeText() {
            if (Control.Checked) {
                Control.Text = Element.TextChecked;
            } else Control.Text = Element.TextUnchecked;

        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName) {
                case "Checked":
                    Control.Checked = Element.Checked;
                    ChangeText();
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
                    break;
            }
        }

        void CheckBoxCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            this.Element.Checked = e.IsChecked;
            ChangeText();
        }

    }
}