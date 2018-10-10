using System;
using System.Linq;

namespace NMEA_GGA_GPS
{
    class Program
    {
        static void Main(string[] args)
        {
        
            //GPS point = new GPS("$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47");
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
    
   public class GPS
    {
        public decimal  Latitude      { get; set; }
        public decimal  Longitude     { get; set; }
        public string   Time          { get; set; }
        public string   LatDirection  { get; set; }
        public string   LongDirection { get; set; }
        public string   Quality       { get; set; }
        public string   Svs           { get; set; }
        public string   HDOP          { get; set; }
        public string   Oheight       { get; set; }
        public string   OheightType   { get; set; }
        public string   Geoid         { get; set; }
        public string   GeoidType     { get; set; }
        public string   Age           { get; set; }
        public string   StationID     { get; set; }
        public string   Checksum      { get; set; }

        public GPS(string coord)
        {
            string[] NMEA = coord.Split(',', '*');
            decimal pLatitude = Convert.ToDecimal(NMEA[2]); 
            decimal pLongitude = Convert.ToDecimal(NMEA[4]);          
            string time = NMEA[1];
            string hh = time.Substring(0,2);
            string mm = time.Substring(2,2);
            string ss = time.Substring(4,2);
            string formattedTime = String.Format("{0}:{1}:{2}", hh, mm, ss);
            
            switch (NMEA[6])
            {
                case "0":
                    Quality = "Fix not valid";
                    break;
                case "1":
                    Quality = "GPS fix";
                    break;
                case "2":
                    Quality = "Differential GPS fix, OmniSTAR VBS";
                    break;
                case "4":
                    Quality = "Real-Time Kinematic, fixed integers";
                    break;
                case "5":
                    Quality = "Real-Time Kinematic, float integers, OmniSTAR XP/HP or Location RTK";
                    break;
                default:
                    Quality = "N/A";
                    break;
            }
            Latitude = pLatitude;
            Longitude = pLongitude;
            Time = formattedTime;
            LatDirection = NMEA[3];
            LongDirection = NMEA[5];
            Svs = NMEA[7];
            HDOP = NMEA[8];
            Oheight = NMEA[9];
            OheightType = NMEA[10];
            Geoid = NMEA[11];
            GeoidType = NMEA[12];
            Age = NMEA[13] == "" ? "N/A: DGPS is not used" : NMEA[13];
            StationID = NMEA[14] == "" ? "reference station ID is selected and no corrections are received" : NMEA[14];
            Checksum = NMEA[15];
        }
    }
}


//Dredges use a GPS Device for navigation which sends out strings that are useful for our positioning programs, one of which is a NMEA GGA string.
//A NMEAA GGA string contains various information such as time, latitude, longitude, altitude
//The challenge is to write a code using C# that can parse a string input and be able to output the data (time, latitude, longitude, etc.)code using C# that can parse a string input and be able to output the data (time, latitude, longitude, etc.)