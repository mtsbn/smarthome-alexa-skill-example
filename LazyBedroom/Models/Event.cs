using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Models
{
    public class Event
    {
        public Header Header { get; set; }
        public Payload Payload { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
