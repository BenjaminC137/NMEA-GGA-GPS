using System;
namespace NMEA_GGA_GPS
{
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
    
