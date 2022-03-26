# Unity Telemetry Client

## Setup
- Open the Unity Package Manager window _(menu bar "Window" > "Package Manager")_.
- Add the package from Git, or add the cloned package from your local file system _(plus button in upper left corner)_.
- For a basic simulationstate test within in Unity, add the TelemetryClientBasic Script as a component to a GameObject in your screen.
- To create an internal TelemetryClient, construct a TelemetryReader with the hostname, port, and shortpolling interval (interval to check for updates in the simulationstate) of the TelemetryServer.
- To handle the incoming simulationstate data via the TelemetryClient, subscribe to the `OnReceiveSimulationState` event.
