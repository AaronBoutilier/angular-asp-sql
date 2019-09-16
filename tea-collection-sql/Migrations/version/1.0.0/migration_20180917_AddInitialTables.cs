using FluentMigrator;

namespace Migrations.version._1._0._0
{
	[MigrationName(author: "Aaron Boutilier", versionNumber: 1, releaseNumber: 1, patchNumber: 0, year: 2019, month: 9, day: 17, hour: 13, minute: 29)]
	public class Migration_20180917_AddInitialTables : Migration
	{
		public override void Down()
		{
			Delete.Table("TeaIngredient");
			Delete.Table("Ingredient");
			Delete.Table("Tea");
		}

		public override void Up()
		{
			Create.Table("Tea")
				.WithColumn("Id").AsInt32().PrimaryKey().Identity()
				.WithColumn("Name").AsString(300).NotNullable();

			Create.Table("Ingredient")
				.WithColumn("Id").AsInt32().PrimaryKey().Identity()
				.WithColumn("Name").AsString(300).NotNullable();


			Create.Table("TeaIngredient")
				.WithColumn("TeaId").AsInt32().NotNullable()
				.WithColumn("IngredientId").AsInt32().NotNullable();

			Create.PrimaryKey("TeaIngredient_PK_Tea_Id_Ingredient_Id").OnTable("TeaIngredient").Columns("TeaId", "IngredientId");
		}
	}
}
