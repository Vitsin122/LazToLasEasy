using Aardvark.Base;
using LazToLasEasy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazToLasEasy
{
    public static class LazConverter
    {
        /// <summary>
        /// Gets from LAZ to local LAS view
        /// </summary>
        /// <param name="filePath">Path where file exist</param>
        /// <returns>Point collection with scaled coordinates</returns>
        public static List<RealLasPoint> Convert(string filePath)
        {
            List<RealLasPoint> points = new List<RealLasPoint>();

            foreach (var positions in LASZip.Parser.ReadPoints(filePath, 1024 * 1024))
            {
                for (int i = 0; i < positions.Positions.Count(); i++)
                {
                    var pointCoordData = positions.Positions[i];
                    var pointClassificateData = positions.Classifications[i];
                    var pointIntensivityData = positions.Intensities[i];
                    var pointColorsData = positions.Colors[i];
                    var pointReturnNumberData = positions.ReturnNumbers[i];
                    var pointNumberOfReturnData = positions.NumberOfReturnsOfPulses[i];
                    var pointScanAngleRanksData = positions.ScanAngleRanks[i];
                    var pointGpsData = positions.GpsTimes[i];
                    var pointUserData = positions.UserDatas[i];
                    var pointSourceIdData = positions.PointSourceIds[i];

                    points.Add(new RealLasPoint
                    {
                        X = pointCoordData.X,
                        Y = pointCoordData.Y,
                        Z = pointCoordData.Z,
                        Classification = pointClassificateData,
                        Red = pointColorsData.R,
                        Blue = pointColorsData.B,
                        Green = pointColorsData.G,
                        Intensity = pointIntensivityData,
                        ReturnNumber = pointReturnNumberData,
                        NumberOfReturns = pointNumberOfReturnData,
                        ScanAngleRank = (byte)pointScanAngleRanksData,
                        GPSTime = pointGpsData,
                        UserData = pointUserData,
                        PointSourceId = pointSourceIdData,
                    });
                }
            }

            return points;
        }
    }
}
