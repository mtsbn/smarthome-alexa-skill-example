using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Models
{
    public class Endpoint
    {
        public string EndpointId { get; set; }
        public string ManufacturerName { get; set; }
        public string Description { get; set; }
        public string FriendlyName { get; set; }
        public Additionalattributes AdditionalAttributes { get; set; }
        public List<string> DisplayCategories { get; set; }
        public Cookie Cookie { get; set; }
        public List<Capability> Capabilities { get; set; }
        public List<Connection> Connections { get; set; }
        public Scope Scope { get; set; }
    }
      
    

}
