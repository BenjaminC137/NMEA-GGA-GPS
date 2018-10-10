using System;

namespace NMEA_GGA_GPS
{
    class Program
    {
        static void Main(string[] args)
        {
        
        }
    }
}


//Dredges use a GPS Device for navigation which sends out strings that are useful for our positioning programs, one of which is a NMEA GGA string.
//A NMEAA GGA string contains various information such as time, latitude, longitude, altitude
//The challenge is to write a code using C# that can parse a string input and be able to output the data (time, latitude, longitude, etc.)