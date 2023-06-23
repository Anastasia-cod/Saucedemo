using AngleSharp;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Core;

public class DataBaseConnector : DbContext
{
    public DbSet<Customers>? Customers { get; set; }

    public DataBaseConnector()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Host={Configurator.DbSettings.Server};" +
            $"Port={Configurator.DbSettings.Port};" +
            $"Database={Configurator.DbSettings.Schema};" +
            $"User Id={Configurator.DbSettings.Username};" +
            $"Password={Configurator.DbSettings.Password};";

        optionsBuilder.UseNpgsql(connectionString);
    }
}