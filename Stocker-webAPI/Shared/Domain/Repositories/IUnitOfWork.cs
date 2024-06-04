namespace Stocker_webAPI.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}