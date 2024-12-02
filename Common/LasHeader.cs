using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazToLasEasy.Common
{
    public struct LasHeader
    {
        public string FileSignature;  // "LASF"
        public ushort FileSourceId;
        public ushort GlobalEncoding;
        public uint ProjectID1;
        public ushort ProjectID2;
        public ushort ProjectID3;
        public byte[] ProjectID4; // [8]
        public byte VersionMajor;
        public byte VersionMinor;
        public string SystemIdentifier; // [32]
        public string GeneratingSoftware; // [32]
        public ushort FileCreationDayOfYear;
        public ushort FileCreationYear;
        public ushort HeaderSize;
        public uint OffsetToPointData;
        public uint NumberOfVariableLengthRecords;
        public byte PointDataFormatId;
        public ushort PointDataRecordLength;
        public uint NumberOfPointRecords;
        public uint[] NumberOfPointsByReturn; // [5]
        public double ScaleFactorX, ScaleFactorY, ScaleFactorZ;
        public double OffsetX, OffsetY, OffsetZ;
        public double MinX, MaxX, MinY, MaxY, MinZ, MaxZ;
    }
}
