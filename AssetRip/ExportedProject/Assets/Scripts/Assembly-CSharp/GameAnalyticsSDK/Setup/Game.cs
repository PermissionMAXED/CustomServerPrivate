namespace GameAnalyticsSDK.Setup
{
	public class Game
	{
		public string Name { get; set; }

		public int ID { get; set; }

		public string GameKey { get; set; }

		public string SecretKey { get; set; }

		public Game(string name, int id, string gameKey, string secretKey)
		{
		}
	}
}
