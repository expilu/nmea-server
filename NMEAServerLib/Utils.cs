using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NMEAServerLib.InstrumentsData;

namespace NMEAServerLib
{
    public static class Utils {

        public static bool isValidFix(FixQualityType fixQuality)
        {
            switch(fixQuality)
            {
                case FixQualityType.REAL_TIME_KINEMATIC:
                case FixQualityType.FLOAT_RTK:
                case FixQualityType.ESTIMATED_DEAD_RECKONING:
                    return false;
                default: return true;
            }
        }
    }
}
