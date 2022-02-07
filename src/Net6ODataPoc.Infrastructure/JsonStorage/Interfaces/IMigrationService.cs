namespace Net6ODataPoc.Infrastructure.JsonStorage.Interfaces;

public interface IMigrationService
{
    Task MigrateStorage(CancellationToken cancellationToken = default);
}
