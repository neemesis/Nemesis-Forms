using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemesis {
    public class NSuggestionBoxEventArgs : EventArgs {
        public readonly string Text;

        public NSuggestionBoxEventArgs(string Text) {
            this.Text = Text;
        }

    }
}
