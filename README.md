# nmea-server
A NMEA TCP server and sentences generator in C#

# How to use

1. Download [NMEAServerLib.dll](https://github.com/expilu/nmea-server/releases/download/v1.0.0.0/NMEAServerLib.dll) and add it to your project references.
2. Initialize the server with [InstrumentsData](https://github.com/expilu/nmea-server/blob/v1.0.0.0/NMEAServerLib/InstrumentsData.cs) and a TCP port. Then start it.
```C#
InstrumentsData instrumentsData = new InstrumentsData(); 
NmeaServer nmeaServer = new NMEAServer(ref instrumentsData, 10110);
nmeaServer.Start();
```
Note that `instrumentsData` is passed by ref, you only need to modify its properties when instruments changes occur.
3. Set the properties of your `instrumentsData`. None of them is mandatory. The server will just send the sentences for which it has enough information. Currently the supported sentences are: **GLL**, **VHW**, **HDT**, **MWV**, **MWV**, **DPT**, **DBT**, **VTG** and **RMC**.
```C#
// Latitude and Longitude should be in +-180 degrees with decimals
instrumentsData.Lat = 28.134529;
instrumentsData.Lon = -15.435154;
instrumentsData.Heading = 47;
instrumentsData.WaterSpeed = 3.5; // in knots
instrumentsData.CourseOverGround = 48;
instrumentsData.SpeedOverGround = 3.4; // in knots
instrumentsData.TrueWindAngle = 260; // in 360 degrees relative to the bow
instrumentsData.TrueWindSpeed = 3.2; // in knots
instrumentsData.ApparentWindAngle = 260; // in 360 degrees relative to the bow
instrumentsData.ApparentWindSpeed = 3.2; // in knots
instrumentsData.Depth = 15.4; // in meters
instrumentsData.TransducerDepth = 1.2; // in meters
```
4. To send NMEA sentences do
```C#
nmeaServer.SendData();
```
You can also initialize the server with a send rate. The server will then send the current `instrumentsData` at the specified rate (in milliseconds). You can still also call `SendData()` any moment you like.
```C#
InstrumentsData instrumentsData = new InstrumentsData(); 
NmeaServer nmeaServer = new NMEAServer(ref instrumentsData, 10110, 10000);
nmeaServer.Start();
```
5. Remember to stop the server when it is not needed anymore
```C#
nmeaServer.Stop();
```

The [NmeaServer](https://github.com/expilu/nmea-server/blob/v1.0.0.0/NMEAServerLib/NMEAServer.cs) has some events you can use: `OnServerStarted`, `OnServerStop`, `OnNMEASent`, `OnClientConnected` and `OnServerError`.
