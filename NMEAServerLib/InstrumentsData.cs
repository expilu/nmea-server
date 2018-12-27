using System;

namespace NMEAServerLib
{
    public class InstrumentsData
    {
        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lon { get; set; }
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

        public String generateNMEA()
        {
            return NMEASentenceGenerator.generate(this);
        }
    }
}
