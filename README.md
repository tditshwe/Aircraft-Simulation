# Aircraft-Simulation

## Overview

This project is based on the first project in a series of Java projects that is part of the [Wethinkcode](https://www.wethinkcode.co.za/) curriculum. It is the introduction to the concept of UML class diagrams and object oriented design patterns. An aircraft simulation application needs to be implemented based on the provided [UML-class-diagram](simulation_uml.jpg).

### Scenario file

This application will be reading from a text file([scenario.txt](bin/Debug/scenario.txt)) that will contain the scenario that needs to be simulated. The first line of the file contains a positive integer number. This number represents the number of times the simulation is run i.e the number of times a weather change is triggered. Each following line describes an aircraft that will be part of the simulation, with this format: `TYPE NAME LONGITUDE LATITUDE HEIGHT` e.g. ``Baloon B1 2 3 5``. The scenario file may be modified to produce different simulation outcomes.

### Weather generation

There are 4 types of weather:
- RAIN
- FOG
- SUN
- SNOW
Each 3 dimensional point (Longitude, Latitude, Height) has its own weather.

### Aircrafts

#### JetPlane:
- SUN - Latitude increases with 10, Height increases with 2
- RAIN - Latitude increases with 5
- FOG - Latitude increases with 1
- SNOW - Height decreases with 7

#### Helicopter:
- SUN - Longitude increases with 10, Height increases with 2
- RAIN - Longitude increases with 5
- FOG - Longitude increases with 1
- SNOW - Height decreases with 12

#### Baloon:
- SUN - Longitude increases with 2, Height increases with 4
- RAIN - Height decreases with 5
- FOG - Height decreases with 3
- SNOW - Height decreases with 15

### Simulation

- Coordinates are positive numbers.
- The height is in the 0-100 range.
- If an aircraft needs to pass the upper limit height it remains at 100.
- Each time an aircraft is created, it receives a unique ID. There can’t be 2 aircrafts with the same ID.
- If an aircraft reaches height 0 or needs to go below it, the aircraft lands, unregisters from the weather tower and logs its current coordinates.
- When a weather change occurs, each aircraft type needs to log a message. The message format is: `TYPE#NAME(UNIQUE_ID): SPECIFIC_MESSAGE` e.g. ``Baloon#B1(1): Even baloons can freeze to death``. A funny message will be appreciated during the correction.
- Each time an aircraft registers or unregisters to/from the weather tower, a message will be logged.

## Prerequisites

Visual Studio 2015 or later

## Running the Application

- Open `AircraftSimulation.csproj` with Visual Studio to launch the project.

- Click the Start button on Visual Studio or press the F5 key to execute the project

- Executing the project will generate a file `bin/Debug/simulation.txt` that describes the outcome of the simulation.