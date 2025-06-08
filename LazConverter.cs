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

            foreach (var positions in LASZip.Parser.ReadPoints("C:\\Users\\Vitsin\\source\\repos\\Las_Converter_Console\\forest_2017_a.laz", 1024 * 1024))
            {
                for (int i = 0; i < positions.Positions.Count(); i++)
                {
                    var pointCoordData = positions?.Positions?[i];
                    var pointClassificateData = positions?.Classifications?[i];
                    var pointIntensivityData = positions?.Intensities?[i];
                    var pointColorsData = positions?.Colors?[i];
                    var pointReturnNumberData = positions?.ReturnNumbers?[i];
                    var pointNumberOfReturnData = positions?.NumberOfReturnsOfPulses?[i];
                    var pointScanAngleRanksData = positions?.ScanAngleRanks?[i];
                    var pointGpsData = positions?.GpsTimes?[i];
                    var pointUserData = positions?.UserDatas?[i];
                    var pointSourceIdData = positions?.PointSourceIds?[i];

                    points.Add(new RealLasPoint
                    {
                        X = pointCoordData?.X ?? 0,
                        Y = pointCoordData?.Y ?? 0,
                        Z = pointCoordData?.Z ?? 0,
                        Classification = pointClassificateData ?? 0,
                        Red = pointColorsData?.R ?? 0,
                        Blue = pointColorsData?.B ?? 0,
                        Green = pointColorsData?.G ?? 0,
                        Intensity = pointIntensivityData ?? 0,
                        ReturnNumber = pointReturnNumberData ?? 0,
                        NumberOfReturns = pointNumberOfReturnData ?? 0,
                        ScanAngleRank = pointScanAngleRanksData ?? 0,
                        GPSTime = pointGpsData ?? 0,
                        UserData = pointUserData ?? 0,
                        PointSourceId = pointSourceIdData ?? 0,
                    });
                }
            }

            return points;
        }
    }
}
