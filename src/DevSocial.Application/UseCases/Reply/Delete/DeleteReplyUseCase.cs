using DevSocial.Domain.Repositories;
using DevSocial.Domain.Repositories.Reply;

namespace DevSocial.Application.UseCases.Reply.Delete;

public class DeleteReplyUseCase : IDeleteReplyUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReplyWriteOnlyRepository  _replyWriteOnlyRepository;
    private readonly IReplyReadOnlyRepository  _replyReadOnlyRepository;

    public DeleteReplyUseCase(IUnitOfWork  unitOfWork,  IReplyWriteOnlyRepository replyWriteOnlyRepository,  IReplyReadOnlyRepository replyReadOnlyRepository)
    {
        _unitOfWork = unitOfWork;
        _replyWriteOnlyRepository = replyWriteOnlyRepository;
        _replyReadOnlyRepository = replyReadOnlyRepository;
    }
    
    public async Task Execute(int id)
    {
        var result = await _replyReadOnlyRepository.GetByIdAsync(id);
        if (result == null)
        {
            throw new Exception("not found");
        }

        await _replyWriteOnlyRepository.Delete(id);
        await _unitOfWork.Commit();
    }
}