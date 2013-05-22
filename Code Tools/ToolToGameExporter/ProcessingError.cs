using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolToGameExporter {
    public class ProcessingError {
        public string type = "";
        public string element = "";
        public string error = "";

        public ProcessingError(string _type, string _element, string _error) {
            this.type = _type;
            this.element = _element;
            this.error = _error;
        }

        public ListViewItem GetAsListViewItem() {
            ListViewItem lvi = new ListViewItem(type);
            lvi.SubItems.Add(element);
            lvi.SubItems.Add(error);

            return lvi;
        }
    }
}
