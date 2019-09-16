using System.Collections.Generic;

namespace Collection.Api.Domain
{
	public class Tea
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<Ingredient> Ingredients { get; set; }
	}
}
