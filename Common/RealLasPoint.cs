using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazToLasEasy.Common
{
    public class RealLasPoint
    {
        public double X, Y, Z;               // Raw unscaled values
        public ushort Intensity;
        public byte ReturnNumber;
        public byte NumberOfReturns;
        public byte Classification;
        public byte ScanAngleRank;
        public byte UserData;
        public ushort PointSourceId;
        public double GPSTime;             // Only if format >= 1
        public ushort Red, Green, Blue;   // Only if format >= 2
    }
}
