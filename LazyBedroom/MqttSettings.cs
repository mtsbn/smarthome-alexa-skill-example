using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom
{
    public class MqttSettings
    {
        public static string MqttClientId = Environment.GetEnvironmentVariable("MQTT_CLIENT_ID");
        public static string MqttHost = Environment.GetEnvironmentVariable("MQTT_HOST");
        public static string MqttUser = Environment.GetEnvironmentVariable("MQTT_USER");
        public static string MqttPassword = Environment.GetEnvironmentVariable("MQTT_PASSWORD");
        public static string MqttDefaultTopic = Environment.GetEnvironmentVariable("MQTT_DEFAULT_TOPIC");

        public static string TurnOnLamp = "10";
        public static string TurnOffLamp = "11";

        public static byte[] LampControlMessage(bool turnOn)
        {
            string pubValue = turnOn ? TurnOnLamp : TurnOffLamp;
            return Encoding.UTF8.GetBytes(pubValue);
        }
    }
}
