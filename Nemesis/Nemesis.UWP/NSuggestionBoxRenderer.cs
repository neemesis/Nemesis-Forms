using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

[assembly: ExportRenderer(typeof(NSuggestionBox), typeof(NSuggestionBoxRenderer))]
namespace Nemesis.UWP {
    public class NSuggestionBoxRenderer : ViewRenderer<NSuggestionBox, AutoSuggestBox> {

        protected override void OnElementChanged(ElementChangedEventArgs<NSuggestionBox> e) {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            if (Control == null) {
                var suggestionBox = new AutoSuggestBox();

                Debug.WriteLine("Text: " + Element.Text);
                Debug.WriteLine("ItemsSource: " + Element.ItemsSource.Count);
                
                suggestionBox.ItemsSource = Element.ItemsSource;
                suggestionBox.TextChanged += suggestionBox_OnTextChanged;
                suggestionBox.SuggestionChosen += suggestionBox_OnSuggestionChosen;
                SetNativeControl(suggestionBox);
            }
        }

        private void suggestionBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args) {
            Element.SelectedText = (string) args.SelectedItem;
        }

        private void suggestionBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args) {
            Element.Text = Control.Text;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName) {
                case "IsVisible":
                    Control.Visibility = Element.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                    break;
                case "ItemsSource":
                    Control.ItemsSource = Element.ItemsSource;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
                case "SelectedText":
                    Control.Text = Element.SelectedText;
                    break;

            }
        }
    }
}
