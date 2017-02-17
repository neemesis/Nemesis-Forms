using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemesis {
    public class NSuggestionBoxEventArgs : EventArgs {
        public string SelectedText;

        public NSuggestionBoxEventArgs(string SelectedText) {
            this.SelectedText = SelectedText;
        }

    }
}
