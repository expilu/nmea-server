using System;
using System.Globalization;
using System.Text;

namespace NMEAServerLib
{
    public class NMEASentenceGenerator
    {
        private enum Coord { Lat, Lon }

        public static String generate(InstrumentsData data)
        {
            string nmea = "";

            if (data.Lat != null && data.Lon != null) nmea += generatePositionSentence_GLL(data.Lat ?? 0, data.Lon ?? 0);
            if (data.TrueHeading != null && data.WaterSpeed != null) nmea += generateSpeedAndHeadingSentence_VHW(data.WaterSpeed ?? 0, data.TrueHeading ?? 0, data.MagneticHeading);
            if (data.TrueHeading != null) nmea += generateTrueHeadingSentence_HDT(data.TrueHeading ?? 0);
            if (data.TrueWindAngle != null && data.TrueWindSpeed != null) nmea += generateTrueWindSpeedAndAngleSentence_MWV(data.TrueWindAngle ?? 0, data.TrueWindSpeed ?? 0);
            if (data.ApparentWindAngle != null && data.ApparentWindSpeed != null) nmea += generateApparentWindSpeedAndAngleSentence_MWV(data.ApparentWindAngle ?? 0, data.ApparentWindSpeed ?? 0);
            if (data.Depth != null && data.TransducerDepth != null) nmea += generateDepthSentence_DPT(data.Depth ?? 0, data.TransducerDepth ?? 0);
            if (data.Depth != null) nmea += generateDepthSentence_DBT(data.Depth ?? 0);
            if (data.CourseOverGround != null && data.SpeedOverGround != null) nmea += generateSpeedAndCourseOverGroundSentence_VTG(data.SpeedOverGround ?? 0, data.CourseOverGround ?? 0, data.MagneticCourseOverGround);
            if (data.Lat != null && data.Lon != null && data.SpeedOverGround != null && data.CourseOverGround != null) nmea += generateRecommendedMinimumInformationSentence_RMC(data.Lat ?? 0, data.Lon ?? 0, data.SpeedOverGround ?? 0, data.CourseOverGround ?? 0);            
            return nmea;
        }

        public static string generatePositionSentence_GLL(double lat, double lon)
        {
            string _lat = ConvertDecimalDegreesToNMEAFormat(lat, Coord.Lat);
            string _lon = ConvertDecimalDegreesToNMEAFormat(lon, Coord.Lon);
            string sentence = "GPGLL," + _lat + "," + _lon + "," + UTCTime() + ",A";
            return FormatSentence(sentence);
        }

        public static string generateSpeedAndHeadingSentence_VHW(double speed, int trueHeading, Nullable<int> magneticHeading)
        {            
            if (magneticHeading == null) magneticHeading = trueHeading;
            string _speedKnots = speed.ToString("F1", CultureInfo.InvariantCulture);
            string _speedKmH = (speed * 1.852).ToString("F0", CultureInfo.InvariantCulture);
            string sentence = "IIVHW," + trueHeading.ToString() + ",T," + magneticHeading.ToString() + ",M," + _speedKnots + ",N," + _speedKmH + ",K";
            return FormatSentence(sentence);
        }

        public static string generateTrueHeadingSentence_HDT(int trueHeading)
        {
            string sentence = "IIHDT," + trueHeading.ToString() + ",T";
            return FormatSentence(sentence);
        }

        public static string generateTrueWindSpeedAndAngleSentence_MWV(int trueWindAngle, double trueWindSpeed)
        {
            string sentence = "WIMWV," + trueWindAngle.ToString() + ",T," + trueWindSpeed.ToString("F1", CultureInfo.InvariantCulture) + ",N,A";
            return FormatSentence(sentence);            
        }

        public static string generateApparentWindSpeedAndAngleSentence_MWV(int apparentWindAngle, double apparentWindSpeed)
        {
            string sentence = "WIMWV," + apparentWindAngle.ToString() + ",R," + apparentWindSpeed.ToString("F1", CultureInfo.InvariantCulture) + ",N,A";
            return FormatSentence(sentence);
        }

        public static string generateDepthSentence_DPT(double depth, double transducerDepth)
        {
            string sentence = "SDDPT," + depth.ToString("F", CultureInfo.InvariantCulture) + "," + transducerDepth.ToString("F", CultureInfo.InvariantCulture);
            return FormatSentence(sentence);
        }

        public static string generateDepthSentence_DBT(double depth)
        {
            string sentence = "SDDBT," + (depth * 3.28084).ToString("F", CultureInfo.InvariantCulture) + ",f," + depth.ToString("F", CultureInfo.InvariantCulture) + ",M," + (depth * 0.546807).ToString("F", CultureInfo.InvariantCulture) + ",F";
            return FormatSentence(sentence);
        }

        public static string generateSpeedAndCourseOverGroundSentence_VTG(double speedOverGround, int courseOverGroud, Nullable<int> magneticCourseOverGround)
        {
            if (magneticCourseOverGround == null) magneticCourseOverGround = courseOverGroud;
            string _speedKnots = speedOverGround.ToString("F1", CultureInfo.InvariantCulture);
            string _speedKmH = (speedOverGround * 1.852).ToString("F1", CultureInfo.InvariantCulture);
            string sentence = "IIVTG," + courseOverGroud + "," + magneticCourseOverGround + "," + _speedKnots + "," + _speedKmH;
            return FormatSentence(sentence);
        }

        public static string generateRecommendedMinimumInformationSentence_RMC(double lat, double lon, double speedOverGround, int courseOverGroud)
        {
            string _lat = ConvertDecimalDegreesToNMEAFormat(lat, Coord.Lat);
            string _lon = ConvertDecimalDegreesToNMEAFormat(lon, Coord.Lon);
            string _sogKnots = speedOverGround.ToString("F1", CultureInfo.InvariantCulture);
            string sentence = "GPRMC," + UTCTime() + ",A," + _lat + "," + _lon + "," + _sogKnots + "," + courseOverGroud + "," + dateDDMMYY() + ",,,";
            return FormatSentence(sentence);
        }

        private static string CalculateCheckSum(String sentence)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(sentence);

            byte checkSumByte = 0x00;
            for (int i = 0; i < bytes.Length; i++) checkSumByte ^= bytes[i];

            return BitConverter.ToString(new byte[1] { checkSumByte });
        }

        private static string FormatSentence(string sentence)
        {
            return "$" + sentence + "*" + CalculateCheckSum(sentence) + "\n";
        }

        private static string ConvertDecimalDegreesToNMEAFormat(double decimalDegrees, Coord coord)
        {
            String cardinal = "";

            switch (coord)
            {
                case Coord.Lat:
                    cardinal = decimalDegrees >= 0 ? "N" : "S";
                    break;
                case Coord.Lon:
                    cardinal = decimalDegrees >= 0 ? "E" : "W";
                    break;
            }

            decimalDegrees = Math.Abs(decimalDegrees);

            double sec = decimalDegrees * 3600;
            int deg = (int)Math.Floor(sec / 3600);
            sec -= deg * 3600;
            double min = sec / 60;

            return deg.ToString("00") + min.ToString("00.0###", CultureInfo.InvariantCulture) + "," + cardinal;
        }

        private static string UTCTime()
        {
            DateTime utc = DateTime.UtcNow;
            return DateTime.UtcNow.ToString("HHmmss.fff");
        }

        private static string dateDDMMYY()
        {
            DateTime utc = DateTime.UtcNow;
            return DateTime.UtcNow.ToString("ddMMyy");
        }
    }
}
