using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Sound {
    public class SoundData {
        public string Filename;
        public string Name;

        public SoundData() { }

        public SoundData(string filename, string name) {
            this.Filename = filename;
            this.Name = name;
        }
    }
}
