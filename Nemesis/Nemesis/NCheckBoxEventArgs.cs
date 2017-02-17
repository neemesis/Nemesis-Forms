using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemesis {
    public class NCheckBoxEventArgs : EventArgs {
        public readonly bool Value;

        public NCheckBoxEventArgs(bool Value) {
            this.Value = Value;
        }
    }
}
