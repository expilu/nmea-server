using System;

namespace NMEAServerLib
{
    public class InstrumentsData
    {
        public enum FixQualityType { NOT_AVAILABLE = 0, GPS = 1, DIFFERENTIAL_GPS = 2, PPS = 3, REAL_TIME_KINEMATIC = 4, FLOAT_RTK = 5, ESTIMATED_DEAD_RECKONING = 6, MANUAL = 7, SIMULATION_MODE = 8 };

        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lon { get; set; }
        public Nullable<FixQualityType> FixQuality { get; set; }
        public Nullable<int> Heading { get; set; }
        public Nullable<int> MagneticHeading { get; set; } // Heading will be used if no magnetic is set
        public Nullable<double> WaterSpeed { get; set; } // knots
        public Nullable<int> TrueWindAngle { get; set; } // 360 degrees relative to heading
        public Nullable<double> TrueWindSpeed { get; set; } // knots
        public Nullable<int> ApparentWindAngle { get; set; } // 360 degrees relative to heading
        public Nullable<double> ApparentWindSpeed { get; set; } // knots
        public Nullable<double> Depth { get; set; } // meters
        public Nullable<double> TransducerDepth { get; set; } // meters
        public Nullable<int> CourseOverGround { get; set; }
        public Nullable<int> MagneticCourseOverGround { get; set; } // true cog will be used if no magnetic is set
        public Nullable<double> SpeedOverGround { get; set; } // knots
        public Nullable<int> SatellitesCount { get; set; } // when generating sentences it will be default to 4 if not set
        public Nullable<bool> Virtual { get; set; } // marks if this data comes from a virtual origin. i.e. a virtual boat from a game

        public String generateNMEA()
        {
            return NMEASentenceGenerator.generate(this);
        }
    }
}
