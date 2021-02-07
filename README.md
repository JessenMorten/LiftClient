# LifxClient

Simple C# client for the [LIFX HTTP API](https://api.developer.lifx.com/docs/).

## How to use

```cs
// Get your API key: https://api.developer.lifx.com/docs/authentication
var apiKey = "your-api-key";

// Create LifxClient
ILifxClient lifxClient = new LifxClient(apiKey);

// Get the bulb you want to control
var officeBulb = (await lifxClient.GetAllAsync()).First(bulb => bulb.Label == "Office");

// Start the 'Pulse' effect
await lifxClient.PulseAsync(officeBulb, color: "red", fromColor: "blue", cycles: 5, period: 1);
```
