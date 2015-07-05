namespace FunMatchGame.Repositories
{
	public class AustralianWarMemorialRootDataModel
	{
		public AustralianWarMemorialDataModel[] results { get; set; }
	}

	public class AustralianWarMemorialDataModel
	{
		public string url { get; set; }
		public string accession_number { get; set; }
		public string id { get; set; }
		public string description { get; set; }
		public string type { get; set; }
		public string title { get; set; }
	}
}