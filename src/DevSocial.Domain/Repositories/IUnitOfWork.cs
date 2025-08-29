namespace DevSocial.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}