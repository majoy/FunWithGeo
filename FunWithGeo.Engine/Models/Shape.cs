using System;
using System.Collections.Generic;
using FunWithGeo.Engine.Extensions;

namespace FunWithGeo.Engine.Models
{
	public class Shape : IEquatable<Shape>
	{
		public string Label { get; private set; }

		public List<Coordinate> Coordinates { get; private set; }

		public Shape(List<Coordinate> coordinates, string label)
		{
			Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));

			Label = label;
		}

		public bool Equals(Shape other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Label, other.Label) && Coordinates.Matches(other.Coordinates);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Shape) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Label != null ? Label.GetHashCode() : 0) * 397) ^ (Coordinates != null ? Coordinates.GetHashCode() : 0);
			}
		}
	}
}
