using System;
using System.Collections.Generic;

namespace ApkgEditor.Structure
{
    public partial class Card
    {
        public long Id { get; set; }
        public long Nid { get; set; }
        public long Did { get; set; }
        public long Ord { get; set; }
        public long Mod { get; set; }
        public long Usn { get; set; }
        public long Type { get; set; }
        public long Queue { get; set; }
        public long Due { get; set; }
        public long Ivl { get; set; }
        public long Factor { get; set; }
        public long Reps { get; set; }
        public long Lapses { get; set; }
        public long Left { get; set; }
        public long Odue { get; set; }
        public long Odid { get; set; }
        public long Flags { get; set; }
        public string Data { get; set; }
    }
}
