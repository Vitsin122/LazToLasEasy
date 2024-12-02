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
        /// <returns></returns>
        public static List<LasPoint> Convert(string filePath)
        {
            List<LasPoint> points = new List<LasPoint>();

            foreach (var positions in LASZip.Parser.ReadPoints(filePath, 1024 * 1024))
            {
                
                foreach(var pos in positions.Positions)
                {
                    
                    points.Add(new LasPoint
                    {
                        X = pos.X,
                        Y = pos.Y,
                        Z = pos.Z,
                    });
                }
            }

            return points;
        }
    }
}
