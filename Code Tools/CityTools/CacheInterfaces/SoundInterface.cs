using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Sound;

namespace CityTools.CacheInterfaces {
    public class SoundInterface {

        public static void PopulateList() {
            MainWindow.instance.cbMapMusic.Items.Clear();

            foreach (SoundData sound in SoundDatabase.Music) {
                MainWindow.instance.cbMapMusic.Items.Add(sound.Name);
            }
        }

    }
}
