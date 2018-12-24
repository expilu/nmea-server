using System;
using System.Collections.Generic;
using System.Text;

namespace NMEALib
{
    public class InstrumentsData
    {

        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lon { get; set; }

        public String generateNMEA()
        {            
            return NMEASentenceGenerator.generate(this);
        }
    }
}
