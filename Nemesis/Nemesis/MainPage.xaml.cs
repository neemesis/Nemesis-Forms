using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nemesis {
    public partial class MainPage {
        public MainPage() {
            InitializeComponent();

            nsbTest.ItemsSource = new ObservableCollection<string> { "str1", "str2" };
        }

        private void NCheckBox_OnCheckedChanged(object sender, EventArgs e) {
            Debug.WriteLine("NCB: " + (sender as NCheckBox).Checked);
        }

        private void NsbTest_OnSelectedTextChanged(object sender, NSuggestionBoxEventArgs e) {
            Debug.WriteLine("NSB: " + e.SelectedText);
        }
    }
}
