using System;
using System.Collections.Generic;

namespace ApkgEditor.Structure
{
    public partial class Notes
    {
        public long Id { get; set; }
        public string Guid { get; set; }
        public long Mid { get; set; }
        public long Mod { get; set; }
        public long Usn { get; set; }
        public string Tags { get; set; }
        public string Flds { get; set; }
        public long Sfld { get; set; }
        public long Csum { get; set; }
        public long Flags { get; set; }
        public string Data { get; set; }
    }
}
