using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Infrastructure;
using System;

namespace Migrations
{
	public static class Extensions
	{
		public static IFluentSyntax CreateTableIfNotExists(this MigrationBase self, string tableName, Func<ICreateTableWithColumnOrSchemaOrDescriptionSyntax, IFluentSyntax> constructTableFunction, string schemaName = "dbo")
			=> self.Schema.Schema(schemaName).Table(tableName).Exists() ? constructTableFunction(self.Create.Table(tableName)) : null;

		public static void CreateForeignKeyIfNotExists(this MigrationBase self, string primaryTable, string primaryField, string fkTable, string fkField, string fkName)
		{
			if (!self.ForeignKeyExists(fkName, primaryTable))
			{
				self.Create.ForeignKey(fkName)
					.FromTable(primaryTable).InSchema("dbo").ForeignColumn(primaryField)
					.ToTable(fkTable).InSchema("dbo").PrimaryColumn(fkField);
			}
		}
		public static void RenameIfExists(this Migration self, string table, string field, string newField)
		{
			if (self.ColumnExists(field, table))
				self.Rename.Column(field).OnTable(table).To(newField);
		}
		public static void CreatePrimaryKeyIfNotExists(this MigrationBase self, string table, string field, string name)
		{
			if (!self.IndexKeyExists(name, table))
				self.Create.PrimaryKey(name).OnTable(table).Column(field);
		}
		public static void DeletePrimaryKeyIfExists(this Migration self, string table, string field, string name)
		{
			if (self.IndexKeyExists(name, table))
				self.Delete
				  .PrimaryKey(name)
				  .FromTable(table)
				  .InSchema("dbo");
		}
		public static void CreateIndexIfNotExists(this MigrationBase self, string table, string indName, string primaryKey)
		{
			if (!self.IndexKeyExists(indName, table))
				self
					.Create
					.Index(indName)
					.OnTable(table)
					.InSchema("dbo")
					.OnColumn(primaryKey);
		}
		public static void DeleteIndexIfExits(this Migration self, string table, string indName)
		{
			if (self.IndexKeyExists(indName, table))
			{
				self.Delete
				  .Index(indName)
				  .OnTable(table)
				  .InSchema("dbo");
			}
		}
		public static void DeleteForeginKeyIfExits(this Migration self, string table, string fkName)
		{
			if (self.ForeignKeyExists(fkName, table))
			{
				self.Delete
				  .ForeignKey(fkName)
				  .OnTable(table)
				  .InSchema("dbo");
			}
		}
		public static void DeleteColumnIfExists(this Migration self, string table, string colName)
		{
			if (self.ColumnExists(colName, table))
			{
				self.Delete
				  .Column(colName)
				  .FromTable(table)
				  .InSchema("dbo");
			}
		}
		private static bool ColumnExists(this MigrationBase self, string columnName, string tableName)
		{
			return self.Schema.Schema("dbo").Table(tableName).Column(columnName).Exists();
		}
		private static bool IndexKeyExists(this MigrationBase self, string indexName, string indexTableName)
		{
			return self.Schema.Schema("dbo").Table(indexTableName).Index(indexName).Exists();
		}
		private static bool ForeignKeyExists(this MigrationBase self, string foreignKeyName, string foreignKeyTableName)
		{
			return self.Schema.Schema("dbo").Table(foreignKeyTableName).Constraint(foreignKeyName).Exists();
		}
	}


	public class MigrationNameAttribute : MigrationAttribute
	{
		public MigrationNameAttribute(int versionNumber, int releaseNumber, int patchNumber, int year, int month, int day, int hour, int minute, string author)
		   : base(CreateVersionNumber(versionNumber, releaseNumber, patchNumber, year, month, day, hour, minute))
		{
			this.Author = author;
		}
		public string Author { get; private set; }
		private static long CreateVersionNumber(int versionNumber, int releaseNumber, int patchNumber, int year, int month, int day, int hour, int minute)
		{
			int calculatedVersion = Convert.ToInt32("" + versionNumber + releaseNumber + patchNumber);
			return calculatedVersion * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
		}
	}
}
