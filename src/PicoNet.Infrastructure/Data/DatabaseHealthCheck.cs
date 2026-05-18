// PicoNet.Infrastructure/Data/DatabaseHealthCheck.cs
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;

namespace PicoNet.Infrastructure.Data;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly string _connectionString;
    
    public DatabaseHealthCheck(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken ct = default)
    {
        try
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync(ct);
            await using var command = new NpgsqlCommand("SELECT 1", connection);
            await command.ExecuteScalarAsync(ct);
            
            return HealthCheckResult.Healthy("PostgreSQL is healthy");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("PostgreSQL is unhealthy", ex);
        }
    }
}