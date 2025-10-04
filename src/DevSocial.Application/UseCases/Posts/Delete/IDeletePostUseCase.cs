namespace DevSocial.Application.UseCases.Posts.Delete;

public interface IDeletePostUseCase
{
    public Task Execute(int id);
}