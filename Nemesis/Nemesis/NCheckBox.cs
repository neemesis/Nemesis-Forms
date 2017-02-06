using System;
using System.ComponentModel;
using Xamarin.Forms;
#pragma warning disable 618

namespace Nemesis {
    public class NCheckBox : View {


        public NCheckBox() {
            Checked = false;
            TextChecked = "On";
            TextUnchecked = "Off";
        }

        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked",
                typeof(bool),
                typeof(NCheckBox),
                false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        public static readonly BindableProperty TextCheckedProperty =
            BindableProperty.Create("TextChecked",
                typeof(string),
                typeof(NCheckBox));

        public static readonly BindableProperty TextUncheckedProperty =
            BindableProperty.Create("TextUnchecked",
                typeof(string),
                typeof(NCheckBox));

        public bool Checked {
            get {
                return (bool)GetValue(CheckedProperty);
            }

            set {
                if (this.Checked != value) {
                    SetValue(CheckedProperty, value);
                    if (CheckedChanged != null)
                        CheckedChanged.Invoke(this, new EventArgs());
                }
            }
        }

        public string TextChecked {
            get {
                return (string)GetValue(TextCheckedProperty);
            }

            set {
                SetValue(TextCheckedProperty, value);
            }
        }

        public string TextUnchecked {
            get {
                return (string)GetValue(TextUncheckedProperty);
            }

            set {
                SetValue(TextUncheckedProperty, value);
            }
        }


        public event EventHandler<EventArgs> CheckedChanged;

        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue) {
            var checkBox = (NCheckBox)bindable;
            checkBox.Checked = (bool)newvalue;
        }
    }
}
