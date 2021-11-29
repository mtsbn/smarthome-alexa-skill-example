using System;
using System.Collections.Generic;

namespace LazyBedroom.Models
{
    public class Properties
    {
        public List<Supported> Supported { get; set; }
        public bool ProactivelyReported { get; set; }
        public bool Retrievable { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime TimeOfSample { get; set; }
        public int UncertaintyInMilliseconds { get; set; }
    }
}
