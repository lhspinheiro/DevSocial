namespace DevSocial.Application.UseCases.Reply.Delete;

public interface IDeleteReplyUseCase
{
    public Task Execute(int id); 
}