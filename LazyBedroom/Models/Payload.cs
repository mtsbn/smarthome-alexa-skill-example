using System.Collections.Generic;

namespace LazyBedroom.Models
{
    public class Payload
    {
        public Grant Grant { get; set; }
        public Grantee Grantee { get; set; }
        public Scope Scope { get; set; }
        public List<Endpoint> Endpoints { get; set; }
    }
}
