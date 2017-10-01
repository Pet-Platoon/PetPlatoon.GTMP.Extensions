using System;
using GrandTheftMultiplayer.Server.Extensions;
using GrandTheftMultiplayer.Shared.Math;
using PetPlatoon.GTMP.Extensions.Extensions;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NonReadonlyMemberInGetHashCode

namespace PetPlatoon.GTMP.Extensions.Math
{
    /// <summary>
    /// A point in a two dimensional space
    /// </summary>
    public class Vector2
    {
        #region Properties

        /// <summary>
        /// The horizontal coordinate of a point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The vertical coordinate of a point
        /// </summary>
        public double Y { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Instantiates a new instance
        /// </summary>
        public Vector2() { }

        /// <summary>
        /// Instantiates a new instance
        /// </summary>
        public Vector2(float x, float y) : this((double)x, y) { }

        /// <summary>
        /// Instantiates a new instance
        /// </summary>
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Returns the length of this point
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return System.Math.Sqrt(LengthSquared());
        }

        /// <summary>
        /// Returns the squared length of this point
        /// </summary>
        /// <returns></returns>
        public double LengthSquared()
        {
            return System.Math.Pow(X, 2) + System.Math.Pow(Y, 2);
        }

        /// <summary>
        /// Returns the distance to another point
        /// </summary>
        /// <returns></returns>
        public double Distance(Vector2 right)
        {
            return System.Math.Sqrt(DistanceSquared(right));
        }

        /// <summary>
        /// Returns the squared distance to another point
        /// </summary>
        /// <returns></returns>
        public double DistanceSquared(Vector2 right)
        {
            return System.Math.Pow(X - right.X, 2) + System.Math.Pow(Y - right.Y, 2);
        }

        /// <summary>
        /// Normalizes this point
        /// </summary>
        public void Normalize()
        {
            var length = Length();

            X /= length;
            Y /= length;
        }

        /// <summary>
        /// Adds a point onto another point
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public Vector2 Add(Vector2 right)
        {
            return this + right;
        }

        /// <summary>
        /// Subtracts a point onto another point
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public Vector2 Subtract(Vector2 right)
        {
            return this - right;
        }

        /// <summary>
        /// Multiplies a point with another point
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public Vector2 Multiply(Vector2 right)
        {
            return this * right;
        }

        /// <summary>
        /// Divides a point with another point
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public Vector2 Divide(Vector2 right)
        {
            return this / right;
        }

        /// <summary>
        /// Returns a random point around a point in a specific radius
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public Vector2 Around(float radius)
        {
            var vector = new Vector2();
            var rng = new Random();
            var rngVal = rng.Next() * new DateTime().Ticks;
            var angle = rngVal * System.Math.PI * 2;
            vector.X = System.Math.Cos(angle) * radius;
            vector.Y = System.Math.Sin(angle) * radius;
            return vector;
        }

        /// <summary>
        /// Returns a point in a three dimensional space
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        public Vector3 ToVector3(float z = 0)
        {
            return new Vector3(X, Y, z);
        }

        #endregion Methods

        #region Static Methods

        /// <summary>
        /// Returns the distance to another point
        /// </summary>
        /// <returns></returns>
        public static double Distance(Vector2 left, Vector2 right)
        {
            return left.Distance(right);
        }

        /// <summary>
        /// Returns the squared distance to another point
        /// </summary>
        /// <returns></returns>
        public static double DistanceSquared(Vector2 left, Vector2 right)
        {
            return left.DistanceSquared(right);
        }

        // Welp, im a lazy fuck <3
#warning TODO: Write something in summary. Maybe a poem or something. I dont know. lol
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vector2 Lerp(Vector2 start, Vector2 end, float n)
        {
            return Vector3.Lerp(start.ToVector3(), end.ToVector3(), n).ToVector2();
        }

        // ReSharper disable once InconsistentNaming
        /// <summary>
        /// Returns a random point
        /// </summary>
        /// <returns></returns>
        public static Vector2 RandomXY()
        {
            var rng = new Random();
            var dt = new DateTime();
            return new Vector2(rng.Next() * dt.Ticks, rng.Next() * dt.Ticks);
        }

        #endregion Static Methods

        #region Operator

        /// <summary>
        /// Adds a point onto another point
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            if (ReferenceEquals(left, null))
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (ReferenceEquals(right, null))
            {
                throw new ArgumentNullException(nameof(right));
            }

            var vec = left.Copy();
            vec.X += right.X;
            vec.Y += right.Y;
            return vec;
        }

        /// <summary>
        /// Subtracts a point onto another point
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            if (ReferenceEquals(left, null))
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (ReferenceEquals(right, null))
            {
                throw new ArgumentNullException(nameof(right));
            }

            var vec = left.Copy();
            vec.X -= right.X;
            vec.Y -= right.Y;
            return vec;
        }

        /// <summary>
        /// Multiplies a point with another point
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            if (ReferenceEquals(left, null))
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (ReferenceEquals(right, null))
            {
                throw new ArgumentNullException(nameof(right));
            }

            var vec = left.Copy();
            vec.X *= right.X;
            vec.Y *= right.Y;
            return vec;
        }

        /// <summary>
        /// Divides a point with another point
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            if (ReferenceEquals(left, null))
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (ReferenceEquals(right, null))
            {
                throw new ArgumentNullException(nameof(right));
            }

            var vec = left.Copy();
            vec.X /= right.X;
            vec.Y /= right.Y;
            return vec;
        }

        /// <summary>
        /// Checks if a point is equal another point with a tolerance of 0.1
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            if (ReferenceEquals(left, null))
            {
                return false;
            }

            if (ReferenceEquals(right, null))
            {
                return false;
            }

            if (ReferenceEquals(left, right))
            {
                return true;
            }

            return System.Math.Abs(left.X - right.X) < 0.1 && System.Math.Abs(left.Y - right.Y) < 0.1;
        }

        /// <summary>
        /// Checks if a point is unequal another point with a tolerance of 0.1
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if a point is equal another point with a tolerance of 0.1
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var vector = obj as Vector2;
            return vector != null &&
                   System.Math.Abs(X - vector.X) < 0.1 &&
                   System.Math.Abs(Y - vector.Y) < 0.1;
        }

        /// <summary>
        /// Returns the hashcode of the current instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        #endregion Operator
    }
}
