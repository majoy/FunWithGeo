namespace FunWithGeo.Website.ApiClients.Models
{
	/// <summary>
	/// Represents a coordinate in the cartesian plane made of a float
	/// </summary>
	public class Coordinate
	{
		public float X { get; set; }
		public float Y { get; set; }

		public Coordinate(float x, float y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return $"({X},{Y})";
		}
	}
}