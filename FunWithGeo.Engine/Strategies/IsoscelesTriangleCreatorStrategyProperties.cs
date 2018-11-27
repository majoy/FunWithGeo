namespace FunWithGeo.Engine.Strategies
{
	public class IsoscelesTriangleCreatorStrategyProperties
	{
		public int GridMaxXCoordinateInPixels { get; set; }
		public int GridMaxYCoordinateInPixels { get; set; }
		public int NonHypotenuseSideLengthInPixels { get; set; }

		/// <summary>
		/// Used to determine how triangles look in the cartesian plane
		/// </summary>
		public TriangleHypotenusePositions TriangleHypotenusePosition { get; set; }
		/// <summary>
		/// Used to determine which triangle gets which label 'A1' or 'A2'
		/// </summary>
		public IncreaseCountOns IncreaseCountOn { get; set; }

		/// <summary>
		/// Indicates whether row starts at y0-going up (StartRowAtY0), or starting from Max-Y-going down (StartRowAtMaxY)
		/// </summary>
		public StartRowOptions StartRowOption { get; set; }

		/// <summary>
		/// Used to determine how triangles look in the cartesian plane
		/// </summary>
		public enum TriangleHypotenusePositions
		{
			ForwardSlashHypotenuse = 1,
			BackslashHypotenuse = 2
		}

		/// <summary>
		/// Used to determine which triangle gets which label 'A1' or 'A2'
		/// </summary>
		public enum IncreaseCountOns
		{
			IncreaseCountOnRightTriangle = 1,
			IncreaseCountOnLeftTriangle = 2
		}

		/// <summary>
		/// Indicates whether row starts at y0-going up (StartRowAtY0), or starting from Max-Y-going down (StartRowAtMaxY)
		/// </summary>
		public enum StartRowOptions
		{
			StartRowAtMaxY = 1,
			StartRowAtY0 = 2,
		}
	}

}