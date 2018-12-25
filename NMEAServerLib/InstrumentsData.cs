using System;

namespace NMEAServerLib
{
    public class InstrumentsData
    {
        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lon { get; set; }
        public Nullable<int> TrueHeading { get; set; }
        public Nullable<int> MagneticHeading { get; set; } // true heading will be used if no magnetic is set
        public Nullable<double> WaterSpeed { get; set; } // knots
        public Nullable<int> TrueWindDirection { get; set; } // 360 degrees relative to north
        public Nullable<double> TrueWindSpeed { get; set; } // knots
        public Nullable<int> ApparentWindDirection { get; set; } // 360 degrees relative to north
        public Nullable<double> ApparentWindSpeed { get; set; } // knots
        public Nullable<double> Depth { get; set; } // meters
        public Nullable<double> TransducerDepth { get; set; } // meters
        public Nullable<int> CourseOverGround { get; set; }
        public Nullable<int> MagneticCourseOverGround { get; set; } // true cog will be used if no magnetic is set
        public Nullable<double> SpeedOverGround { get; set; } // knots

        public String generateNMEA()
        {
            return NMEASentenceGenerator.generate(this);
        }
    }
}
