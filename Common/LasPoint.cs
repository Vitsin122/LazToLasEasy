using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazToLasEasy.Common
{
    public struct LasPoint
    {
        public double X, Y, Z; // Scaled values
        public ushort Intensity;
        public byte ReturnNumber;
        public byte NumberOfReturns;
        public byte ScanDirectionFlag;
        public byte EdgeOfFlightLine;
        public byte Classification;
        public sbyte ScanAngleRank;
        public byte UserData;
        public ushort PointSourceId;
        public ushort Red, Green, Blue; // For LAS with color
    }
}
