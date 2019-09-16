using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Migrations;
using System;

namespace Migrator
{
	class Program
	{
		private const string ConnectionString = "Server = 127.0.0.1; Database = TeaCollection; User Id = sa; Password = password1! ";

		static void Main(string[] args)
		{
			IServiceProvider serviceProvider = CreateServices(ConnectionString);
			UpgradeDatabase(serviceProvider);
		}

		private static IServiceProvider CreateServices(string connection)
		{
			return new ServiceCollection()
				.AddFluentMigratorCore()
				.ConfigureRunner(rb => rb
					.AddSqlServer()
					.WithGlobalConnectionString(connection)
					.WithGlobalCommandTimeout(new TimeSpan(0, 10, 0))
					.ScanIn(typeof(MigrationNameAttribute).Assembly).For.Migrations())
				.AddLogging(lb => lb.AddFluentMigratorConsole())
				.BuildServiceProvider(false);
		}

		private static void UpgradeDatabase(IServiceProvider serviceProvider)
		{
			try
			{
				var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
				runner.MigrateUp();

				Console.WriteLine("The database was successfully updated.");
				Console.ReadLine();
			}
			catch (Exception)
			{
				Console.WriteLine("Something went terribly wrong and the database was not updated.");
				Console.ReadLine();
			}
		}

		private static void DowngradeDatabase(IServiceProvider serviceProvider)
		{
			try
			{
				var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
				runner.Rollback(1);

				Console.WriteLine("The database was successfully down graded.");
				Console.ReadLine();
			}
			catch (Exception)
			{
				Console.WriteLine("Something went terribly wrong and the database was not down graded.");
				Console.ReadLine();
			}
		}
	}
}
