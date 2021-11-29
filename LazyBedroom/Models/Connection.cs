using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Models
{
    public class Connection
    {
        public string Type { get; set; }
        public string MacAddress { get; set; }
        public string HomeId { get; set; }
        public string NodeId { get; set; }
        public string Value { get; set; }
    }
}
