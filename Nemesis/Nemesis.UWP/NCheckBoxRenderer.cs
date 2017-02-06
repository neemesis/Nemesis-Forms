using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Nemesis;
using Nemesis.UWP;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms.PlatformConfiguration;

[assembly: ExportRenderer(typeof(NCheckBox), typeof(NCheckBoxRenderer))]
namespace Nemesis.UWP
{
    public class NCheckBoxRenderer : ViewRenderer<NCheckBox, CheckBox>
    {

        public new static void Init() {
            var temp = DateTime.Now;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NCheckBox> e) {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            if (Control == null) {
                var checkBox = new CheckBox();
                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;
                if (checkBox.IsChecked.GetValueOrDefault())
                    checkBox.Content = Element.TextChecked;
                else
                    checkBox.Content = Element.TextUnchecked;
                SetNativeControl(checkBox);
            }

        }

        private void ChangeText() {
            if (Control.IsChecked.GetValueOrDefault()) {
                Control.Content = Element.TextChecked;
            } else Control.Content = Element.TextUnchecked;

        }

        private void CheckBox_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            Element.Checked = Control.IsChecked.GetValueOrDefault();
            ChangeText();
        }

        private void CheckBox_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e) {
            Element.Checked = Control.IsChecked.GetValueOrDefault();
            ChangeText();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName) {
                //case "IsVisible":
                //    Control.Hidden = Element.IsVisible;
                //    break;
                case "IsEnabled":
                    Control.IsEnabled = Element.IsEnabled;
                    break;
                case "Checked":
                    Control.IsChecked = Element.Checked;
                    ChangeText();
                    break;

            }
        }
    }

}
