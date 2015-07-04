using System;

namespace FunMatchGame.Models
{
	public class Card
	{
		public Card(Guid id, string name, string imageUrl, string sourceUrl, string caption)
		{
			Id = id;
			Name = name;
			ImageUrl = imageUrl;
			SourceUrl = sourceUrl;
			Caption = caption;
		}

		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public string ImageUrl { get; private set; }
		public string SourceUrl { get; private set; }
		public string Caption { get; private set; }
	}
}