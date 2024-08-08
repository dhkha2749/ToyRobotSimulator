# Toy Robot Simulator

## Description
A C# implementation of the Toy Robot Simulator.

## Requirements
- .NET 5.0 or later

## Running the Simulator
1. Clone the repository.
2. Build the solution using Visual Studio or `dotnet build`.
3. Run the simulator using `dotnet run`.

## Running Tests
1. Navigate to the `ToyRobotSimulator.Tests` directory.
2. Run the tests using `dotnet test`.

## Usage
The simulator accepts the following commands:
- `PLACE X,Y,F` - Places the robot at (X,Y) facing F.
- `MOVE` - Moves the robot forward in the current direction.
- `LEFT`/`RIGHT` - Rotates the robot 90 degrees in the specified direction.
- `REPORT` - Outputs the robot's current position.
