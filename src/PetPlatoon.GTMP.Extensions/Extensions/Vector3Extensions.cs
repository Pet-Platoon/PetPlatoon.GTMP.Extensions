using GrandTheftMultiplayer.Shared.Math;
using PetPlatoon.GTMP.Extensions.Math;

namespace PetPlatoon.GTMP.Extensions.Extensions
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Returns a point in a two dimensional space
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}
