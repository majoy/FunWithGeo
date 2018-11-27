using System;

namespace FunWithGeo.Engine.Models
{
	/// <summary>
	/// Represents a coordinate
	/// </summary>
	public class Coordinate : IEquatable<Coordinate>, ICloneable
	{
		public Coordinate(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X { get; set; }
		public float Y { get; set; }

		public Coordinate FindCoordinateByMovingOnYAxis(int pixelsToMoveBy)
		{
			return new Coordinate(X, Y + pixelsToMoveBy);
		}

		public Coordinate FindCoordinateByMovingOnXAxis(int pixelsToMoveBy)
		{
			return new Coordinate(X + pixelsToMoveBy, Y);
		}

		public bool Equals(Coordinate other)
		{
			return other.X == X && other.Y == Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals(obj as Coordinate);
		}

		public override int GetHashCode()
		{
			return (X, Y).GetHashCode();
		}

		public object Clone()
		{
			return new Coordinate(X, Y);
		}


		public override string ToString()
		{
			return $"({X}, {Y})";
		}


		public static bool operator ==(Coordinate coor1, Coordinate coor2)
		{
			return coor1.Equals(coor2);
		}

		public static bool operator !=(Coordinate coor1, Coordinate coor2)
		{
			return !(coor1 == coor2);
		}

	}
}
