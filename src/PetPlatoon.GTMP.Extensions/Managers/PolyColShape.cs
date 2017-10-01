using System;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;
using PetPlatoon.GTMP.Extensions.Extensions;
using PetPlatoon.GTMP.Extensions.Math;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace PetPlatoon.GTMP.Extensions.Managers
{
    /// <summary>
    /// A polygonal collision shape
    /// </summary>
    public class PolyColShape : ColShape
    {
        #region Properties

        /// <summary>
        /// The list of points
        /// </summary>
        public Vector2[] Poly { get; }

        /// <summary>
        /// The base height of the PolyColShape
        /// </summary>
        public float Z { get; }

        /// <summary>
        /// The height of the PolyColShape relative to the Z coordinate
        /// </summary>
        public float Height { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Creates a new PolyColShape
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="z"></param>
        /// <param name="height"></param>
        internal PolyColShape(Vector2[] poly, float z, float height)
        {
            if (poly.Length < 3)
            {
                throw new ArgumentException("You need at least 3 points for a PolyColShape", nameof(poly));
            }

            Poly = poly;
            Z = z;
            Height = height;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Checks if a point in a three dimensional space is inside the PolyColShape
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public override bool Check(Vector3 pos)
        {
            if (pos.Z < Z || pos.Z > Z + Height)
            {
                return false;
            }

            return Check(pos.ToVector2());
        }

        /// <summary>
        /// Source: https://en.wikipedia.org/wiki/Even%E2%80%93odd_rule
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool Check(Vector2 pos)
        {
            var num = Poly.Length;
            var j = num - 1;
            var c = false;
            for (var i = 0; i < num; i++)
            {
                if (Poly[i].Y > pos.Y != Poly[j].Y > pos.Y && pos.X < (Poly[j].X - Poly[i].X) * (pos.Y - Poly[i].Y) / (Poly[j].Y - Poly[i].Y) + Poly[i].X)
                {
                    c = !c;
                }
                j = i;
            }

            return c;
        }

        #endregion Methods
    }
}
