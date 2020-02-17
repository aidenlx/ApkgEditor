using System;
using System.Collections.Generic;

namespace ApkgEditor.Structure
{
    public partial class Revlog
    {
        public long Id { get; set; }
        public long Cid { get; set; }
        public long Usn { get; set; }
        public long Ease { get; set; }
        public long Ivl { get; set; }
        public long LastIvl { get; set; }
        public long Factor { get; set; }
        public long Time { get; set; }
        public long Type { get; set; }
    }
}
