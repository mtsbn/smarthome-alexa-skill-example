using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Models
{
    public class Capability
    {
        public string Type { get; set; }
        public string Interface { get; set; }
        public string Version { get; set; }
        public Properties Properties { get; set; }
    }
}
