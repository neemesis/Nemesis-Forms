using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nemesis;
using Nemesis.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NSuggestionBox), typeof(NSuggestionBoxRenderer))]
namespace Nemesis.Droid {
    public class NSuggestionBoxRenderer : ViewRenderer<NSuggestionBox, AutoCompleteTextView> {
        protected override void OnElementChanged(ElementChangedEventArgs<NSuggestionBox> e) {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            if (Control == null) {
                var checkBox = new AutoCompleteTextView(Forms.Context);


                checkBox.Adapter = GetAdapter(Element.ItemsSource);

                checkBox.TextChanged += checkBox_TextChanged;
                checkBox.ItemSelected += checkBox_ItemSelected;
                checkBox.ItemClick += this.checkBox_ItemClick;

                SetNativeControl(checkBox);
            }
        }

        private void checkBox_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            Element.SelectedText = (sender as AutoCompleteTextView).Text;
        }

        private void checkBox_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
            Element.SelectedText = (sender as AutoCompleteTextView).Text;
        }

        private void checkBox_TextChanged(object sender, Android.Text.TextChangedEventArgs e) {
            Element.Text = (sender as AutoCompleteTextView).Text;
        }

        private ArrayAdapter<string> GetAdapter(ObservableCollection<string> oc) {
            return new ArrayAdapter<string>(Forms.Context, Android.Resource.Layout.SimpleDropDownItem1Line, oc.ToArray());
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName) {
                case "IsVisible":
                    //Control.Visibility = Element.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                    Control.Visibility = Element.IsVisible ? ViewStates.Visible : ViewStates.Gone;
                    break;
                case "ItemsSource":
                    Control.Adapter = GetAdapter(Element.ItemsSource);
                    break;
                case "Text":
                    //Control.Text = Element.Text;
                    break;
                case "SelectedText":
                    //Control.Text = Element.SelectedText;
                    break;

            }
        }
    }
}