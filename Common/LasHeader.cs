using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazToLasEasy.Common
{
    public class LasHeader
    {
        public string FileSignature;
        public ushort FileSourceId;
        public ushort GlobalEncoding;
        public uint ProjectIdGuid1;
        public ushort ProjectIdGuid2;
        public ushort ProjectIdGuid3;
        public byte[] ProjectIdGuid4;
        public byte VersionMajor;
        public byte VersionMinor;
        public string SystemIdentifier;
        public string GeneratingSoftware;
        public ushort FileCreationDay;
        public ushort FileCreationYear;
        public ushort HeaderSize;
        public uint OffsetToPointData;
        public uint NumVariableLengthRecords;
        public byte PointDataFormat;
        public ushort PointDataRecordLength;
        public uint NumPointRecords;
        public uint[] NumPointsByReturn;
        public double XScale, YScale, ZScale;
        public double XOffset, YOffset, ZOffset;
        public double MaxX, MinX, MaxY, MinY, MaxZ, MinZ;
    }
}
