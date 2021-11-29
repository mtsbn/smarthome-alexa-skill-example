# smarthome-alexa-skill-example
Alexa skill para controlar uma lâmpada via MQTT

Antes de executar, é necessário criar o arquivo *launchSettings.json* em *LazyBedrom/Properties* com o conteúdo abaixo: 

```json
{
  "profiles": {
    "Mock Lambda Test Tool": {
      "commandName": "Executable",
      "executablePath": "%USERPROFILE%\\.dotnet\\tools\\dotnet-lambda-test-tool-3.1.exe",
      "commandLineArgs": "--port 5050",
      "workingDirectory": ".\\bin\\$(Configuration)\\netcoreapp3.1",
      "environmentVariables": {
        "MQTT_DEFAULT_TOPIC": "TOPIC HERE",
        "MQTT_USER": "YOUR USER HERE",
        "MQTT_PASSWORD": "YOUR PASSWORD HERE",
        "MQTT_HOST": "YOUR MQTT HOST HERE",
        "MQTT_CLIENT_ID": "YOUR MQTT CLIENT ID HERE (MUST BE UNIQUE)"
      }
    }
  }
}
```
