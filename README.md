# MPESACallbackDeserialization
MPESA callback de-serialization using System.Text.Json implementation

## Background
With the introduction of `System.Text.Json`, dynamic serialization is not yet supported - slated for .NET 5. This therefore 
means that serialization within a controller for some dynamic parameters may not be possible. 

## Steps
1.  Go through the models definitions in the `Models` folder. These define the base data for MPESA callback data.
2.  Check in the `Converters` folder to review the JsonConverter for `KeyValueParameter`. If using 
[ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - note that the converter has been registered on the `KeyValueParameter`
model, another is to register it in dependencies container.
3.  For ASP.NET Core controller view, the `CallbackResponse` is the data type to receive from the callback.
