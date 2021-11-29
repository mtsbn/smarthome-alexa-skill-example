using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using LazyBedroom.Enums;
using LazyBedroom.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using LazyBedroom.Helpers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LazyBedroom
{
    public class Function
    {
        private readonly MqttClient client;        

        public Function ()
        {
            if (client == null)
            {               
                client = new MqttClient(MqttSettings.MqttHost);

                client.Connect(MqttSettings.MqttClientId, MqttSettings.MqttUser, MqttSettings.MqttPassword);
            }
        }

        /// <summary>
        /// Alexa smarthome skill
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<object> FunctionHandler(AlexaRequest input, ILambdaContext context)
        {            
            switch (input?.Directive?.Header?.Namespace)
            {
                case "Alexa.Authorization":
                    {
                        if (input?.Directive?.Header?.Name == "AcceptGrant")
                            return AlexaAcceptGrantRequest(input);
                        break;
                    }
                case "Alexa.Discovery":
                    {
                        if (input?.Directive?.Header?.Name == "Discover")
                            return AlexaDiscoveryRequest(input);
                        break;
                    }
                case "Alexa.PowerController":
                    {
                        if (input?.Directive?.Header?.Name == "TurnOn")                        
                            return await AlexaTurnOnRequest(input);
                        
                        else if (input?.Directive?.Header?.Name == "TurnOff")                        
                            return await AlexaTurnOffRequest(input);
                        
                        break;
                    }
            };         
            return null;                                
        }

        private async Task<object> AlexaTurnOnRequest(AlexaRequest input)
        {
            await MqttLightControl(true);

            var response = new AlexaResponse();

            response.PowerControlResponse(PowerControllerType.ON, input.Directive.Endpoint);

            return response.SerializeResponse();            
        }
        
        private async Task<object> AlexaTurnOffRequest(AlexaRequest input)
        {

            await MqttLightControl(false);

            var response = new AlexaResponse();

            response.PowerControlResponse(
                type: PowerControllerType.OFF, 
                endpoint: input.Directive.Endpoint
                );

            return response.SerializeResponse();
        }

        private object AlexaDiscoveryRequest(AlexaRequest input)
        {
            var response = new AlexaResponse();

            response.DiscoveryResponse(
                endpointId: "LS:LAMP:1:1",
                description: "Lâmpada inteligente NodeMcu",
                name: "Lâmpada do quarto"
                );

            return response.SerializeResponse();
        }

        private object AlexaAcceptGrantRequest(AlexaRequest input)
        {
            var response = new AlexaResponse();

            response.AuthorizeResponse();

            return response.SerializeResponse();
        }

        private async Task MqttLightControl(bool on)
        {
            try
            {                                
                client.Publish(
                    topic: MqttSettings.MqttDefaultTopic, 
                    message: MqttSettings.LampControlMessage(on), 
                    qosLevel: MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, 
                    retain: false
                    );             
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }       
    }
}
