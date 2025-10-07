using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Repositories.User;
using DevSocial.Domain.Security.Cyptography;
using DevSocial.Domain.Security.Tokens;
using DevSocial.Exception.ExceptionBase;

namespace DevSocial.Application.UseCases.Login;

public class DologinUseCase : IDologinUseCase
{
    private readonly IUserReadOnlyRepository  _repository;
    private readonly IPasswordEncripter  _passwordEncripter;
    private readonly IAcessTokenGenerator  _acessTokenGenerator;

    public DologinUseCase(IUserReadOnlyRepository  repository,  IPasswordEncripter  passwordEncripter,  IAcessTokenGenerator  acessTokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _acessTokenGenerator = acessTokenGenerator;
    }
    
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncripter.verify(request.Password, user.Password);

        if (passwordMatch == false)
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Username = user.Username,
            Token = _acessTokenGenerator.GenerateToken(user)
        };
    }
}