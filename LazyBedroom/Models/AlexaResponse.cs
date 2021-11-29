using LazyBedroom.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Models
{
    public class AlexaResponse
    {
        public Event Event { get; set; }
        public Context Context { get; set; }

        public void PowerControlResponse(PowerControllerType type, Endpoint endpoint)
        {
            Event = new Event
            {
                Header = new Header
                {
                    Namespace = "Alexa",
                    Name = "Response",
                    MessageId = Guid.NewGuid().ToString(),
                    PayloadVersion = "3"
                },
                Endpoint = endpoint
            };

            Context = new Context
            {
                Properties = new List<Properties>
                    {
                        new Properties
                        {
                            Namespace = "Alexa.PowerController",
                            Name = "powerState",
                            Value = type == PowerControllerType.ON ? "ON" : "OFF",
                            TimeOfSample = DateTime.Now,
                            UncertaintyInMilliseconds = 500
                        }
                    }
            };
            
        }
        public void DiscoveryResponse(string endpointId, string description, string name)
        {
            Event = new Event
            {
                Header = new Header
                {
                    Namespace = "Alexa.Discovery",
                    Name = "Discover.Response",
                    PayloadVersion = "3",
                    MessageId = Guid.NewGuid().ToString()
                },
                Payload = new Payload
                {
                    Endpoints = new List<Endpoint>
                        {
                            new Endpoint
                            {
                                EndpointId = endpointId,
                                ManufacturerName = "Lazy Company",
                                Description = description,
                                FriendlyName = name,
                                AdditionalAttributes = new Additionalattributes
                                {
                                    Manufacturer = "Lazy Company",
                                    Model = "Lazy Lamp",
                                    SerialNumber = "U00000001",
                                    FirmwareVersion = "0.0.1",
                                    SoftwareVersion = "0.0.1",
                                    CustomIdentifier = "LSLP"
                                },
                                DisplayCategories = new List<string> {"LIGHT"},
                                Cookie = null,
                                Capabilities = new List<Capability>
                                {
                                    new Capability
                                    {
                                        Type = "AlexaInterface",
                                        Interface = "Alexa.PowerController",
                                        Version = "3",
                                    },
                                    new Capability
                                    {
                                        Type = "AlexaInterface",
                                        Interface = "Alexa",
                                        Version = "3"
                                    }
                                },
                                Connections = null
                            }
                        }
                }
            };
        }
        public void AuthorizeResponse()
        {
            Event = new Event
            {
                Header = new Header
                {
                    Namespace = "Alexa.Authorization",
                    Name = "AcceptGrant.Response",
                    MessageId = Guid.NewGuid().ToString(),
                    PayloadVersion = "3"
                },
                Payload = { }
            };
        }
            
    }   
 


}
