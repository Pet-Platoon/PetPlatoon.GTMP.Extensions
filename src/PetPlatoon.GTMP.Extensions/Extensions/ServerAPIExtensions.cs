using System;
using GrandTheftMultiplayer.Server.API;
using PetPlatoon.GTMP.Extensions.Managers;
using PetPlatoon.GTMP.Extensions.Math;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace PetPlatoon.GTMP.Extensions.Extensions
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class ServerAPIExtensions
    {
        /// <summary>
        /// Creates a new PolyColShape
        /// </summary>
        /// <param name="api"></param>
        /// <param name="points"></param>
        /// <param name="z"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static PolyColShape CreatePolyColShape(this ServerAPI api, Vector2[] points, float z, float height)
        {
            if (points.Length < 3)
            {
                throw new ArgumentException("You need at least 3 points for a PolyColShape", nameof(points));
            }

            var colShape = new PolyColShape(points, z, height);
            api.registerCustomColShape(colShape);
            return colShape;
        }
    }
}
