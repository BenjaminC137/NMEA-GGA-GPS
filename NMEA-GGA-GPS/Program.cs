using System;
using System.Linq;

namespace NMEA_GGA_GPS
{
    class Program
    {
        static void Main(string[] args)
        {
            GPS point = new GPS("$GPGGA,134658.00,5106.9792,N,11402.3003,W,2,09,1.0,1048.47,M,-16.27,M,08,AAAA*60");
            
            Console.WriteLine("Latitude: {0} {1} \nLongitude: {2} {3} \nTime: {4} \nQuality: {5} \n#SVs: {6} \nHDOP: {7} \nOrthometric height: {8} {9} \nGeoid separation: {10} {11} \nRecord Age: {12} \nReference Station ID: {13} \nChecksum: {14}",
                              point.Latitude,
                              point.LatDirection,
                              point.Longitude,
                              point.LongDirection,
                              point.Time,
                              point.Quality,
                              point.Svs,
                              point.HDOP,
                              point.Oheight,
                              point.OheightType,
                              point.Geoid,
                              point.GeoidType,
                              point.Age,
                              point.StationID,
                              point.Checksum);         
        }
    }
}
