namespace BAPBAP.UI
{
	public class FractalsPurchaseModel : Model
	{
		public class Listing
		{
			public string listingId;

			public int fractals;

			public float cost;

			public float bonus;
		}

		public Listing[] listings;
	}
}
