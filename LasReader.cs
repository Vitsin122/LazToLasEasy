using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazToLasEasy.Common;

namespace LazToLasEasy
{
    public class LasReader
    {
        public static (LasHeader, List<LasPoint>) ReadLasFile(string filePath)
        {
            using var reader = new BinaryReader(File.Open(filePath, FileMode.Open));

            // Читаем заголовок
            var header = new LasHeader
            {
                FileSignature = new string(reader.ReadChars(4)),
                FileSourceId = reader.ReadUInt16(),
                GlobalEncoding = reader.ReadUInt16(),
                ProjectID1 = reader.ReadUInt32(),
                ProjectID2 = reader.ReadUInt16(),
                ProjectID3 = reader.ReadUInt16(),
                ProjectID4 = reader.ReadBytes(8),
                VersionMajor = reader.ReadByte(),
                VersionMinor = reader.ReadByte(),
                SystemIdentifier = new string(reader.ReadChars(32)).TrimEnd('\0'),
                GeneratingSoftware = new string(reader.ReadChars(32)).TrimEnd('\0'),
                FileCreationDayOfYear = reader.ReadUInt16(),
                FileCreationYear = reader.ReadUInt16(),
                HeaderSize = reader.ReadUInt16(),
                OffsetToPointData = reader.ReadUInt32(),
                NumberOfVariableLengthRecords = reader.ReadUInt32(),
                PointDataFormatId = reader.ReadByte(),
                PointDataRecordLength = reader.ReadUInt16(),
                NumberOfPointRecords = reader.ReadUInt32(),
                NumberOfPointsByReturn = new uint[5]
            };

            for (int i = 0; i < 5; i++)
                header.NumberOfPointsByReturn[i] = reader.ReadUInt32();

            header.ScaleFactorX = reader.ReadDouble();
            header.ScaleFactorY = reader.ReadDouble();
            header.ScaleFactorZ = reader.ReadDouble();
            header.OffsetX = reader.ReadDouble();
            header.OffsetY = reader.ReadDouble();
            header.OffsetZ = reader.ReadDouble();
            header.MinX = reader.ReadDouble();
            header.MaxX = reader.ReadDouble();
            header.MinY = reader.ReadDouble();
            header.MaxY = reader.ReadDouble();
            header.MinZ = reader.ReadDouble();
            header.MaxZ = reader.ReadDouble();

            // Переходим к данным точек
            reader.BaseStream.Seek(header.OffsetToPointData, SeekOrigin.Begin);
            var points = new List<LasPoint>();

            for (int i = 0; i < header.NumberOfPointRecords; i++)
            {
                var point = new LasPoint
                {
                    X = reader.ReadInt32(),
                    Y = reader.ReadInt32(),
                    Z = reader.ReadInt32(),
                    Intensity = reader.ReadUInt16(),
                    ReturnNumber = (byte)(reader.ReadByte() & 0b00000111),
                    NumberOfReturns = (byte)((reader.ReadByte() >> 3) & 0b00000111),
                    ScanDirectionFlag = (byte)((reader.ReadByte() >> 6) & 0b00000001),
                    EdgeOfFlightLine = (byte)((reader.ReadByte() >> 7) & 0b00000001),
                    Classification = reader.ReadByte(),
                    ScanAngleRank = reader.ReadSByte(),
                    UserData = reader.ReadByte(),
                    PointSourceId = reader.ReadUInt16()
                };

                if (header.PointDataFormatId == 2 || header.PointDataFormatId == 3)
                {
                    point.Red = reader.ReadUInt16();
                    point.Green = reader.ReadUInt16();
                    point.Blue = reader.ReadUInt16();
                }

                points.Add(point);
            }

            return (header, points);
        }
    }
}
