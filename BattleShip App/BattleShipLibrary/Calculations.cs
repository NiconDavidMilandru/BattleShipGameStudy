using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    public static class Calculations
    {
        public static int AbsInt(int x)
        {
            if (x < 0)
                return x * -1;
            return x;
        }
        public static double AbsDouble(double x)
        {
            if (x < 0)
                return x * -1.0;
            return x;
        }
    }
}
