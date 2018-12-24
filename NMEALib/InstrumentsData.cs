using System;
using System.Collections.Generic;
using System.Text;

namespace NMEALib
{
    public class InstrumentsData
    {

        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lon { get; set; }
        public Nullable<double> TrueHeading { get; set; }
        public Nullable<double> MagneticHeading { get; set; }
        public Nullable<double> Speed { get; set; }

        public String generateNMEA()
        {            
            return NMEASentenceGenerator.generate(this);
        }
    }
}
