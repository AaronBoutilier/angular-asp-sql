using Collection.Api.Domain;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Collection.Domain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeaController : ControllerBase
	{
		private const string ConnectionString = "Server = database; Database = TeaCollection; User Id = sa; Password = password1!";

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Tea>> Get()
		{
			string sqlTeaList = "SELECT Id, Name FROM Tea;";
			List<Tea> teas = new List<Tea>();

			using (var connection = new SqlConnection(ConnectionString))
				teas = connection.Query<Tea>(sqlTeaList).ToList();

			return teas;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<Tea> Get(int id)
		{
			string sqlTeaList = $"SELECT Id, Name FROM Tea where Id = {id};";
			string sqlTeaIngredientList = $"SELECT i.Id, i.Name FROM Ingredient i JOIN TeaIngredient ti ON i.Id = ti.IngredientId where ti.TeaId = {id};";

			Tea tea;

			using (var connection = new SqlConnection(ConnectionString))
			{
				tea = connection.QueryFirstOrDefault<Tea>(sqlTeaList);

				tea.Ingredients = connection.Query<Ingredient>(sqlTeaIngredientList).ToList();
			}

			return tea;
		}

		// GET api/values/5
		[HttpGet("populate-db")]
		public ActionResult<Tea> PopulateDb()
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				connection.Execute(@"
DELETE FROM [TeaIngredient]
DELETE FROM [Ingredient]
DELETE FROM [Tea]
INSERT INTO [Tea] ([Name]) VALUES ('Fruit Blast Tea'), ('Apple Tea'), ('Orange Tea'), ('Pear Tea'), ('Plum Tea')
INSERT INTO [Ingredient] ([Name]) VALUES ('Apple'), ('Orange'), ('Pear'), ('Plum'), ('White Tea'), ('Black Tea')
INSERT INTO [TeaIngredient] ([TeaId],[IngredientId]) VALUES (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (2, 1), (2, 5), (3, 2), (3, 5), (4, 3), (4, 5), (5, 4), (5, 6)
");
			}

			return null;
		}
	}
}
