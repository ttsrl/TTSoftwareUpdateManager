using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTSoftwareUpdateManager
{
    public class SFTW
    {
        private List<SFTWElement> list = new List<SFTWElement>();
        public int Count { get => list.Count; }
        public List<SFTWElement> Items { get => list; }
        
        public void Add(SFTWElement item)
        {
            list.Add(item);
        }
    }

    public class SFTWElement
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<string> Files { get; set; }
    }
}
