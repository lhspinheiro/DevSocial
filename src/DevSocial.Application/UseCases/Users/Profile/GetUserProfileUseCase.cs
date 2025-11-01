using AutoMapper;
using DevSocial.Communication.Response;
using DevSocial.Domain.Services.LoggedUser;

namespace DevSocial.Application.UseCases.Users.Profile;

public class GetUserProfileUseCase : IGetUserProfileUseCase
{
    private readonly IMapper  _mapper;
    private readonly ILoggedUser  _loggedUser;

    public GetUserProfileUseCase(IMapper  mapper, ILoggedUser loggedUser)
    {
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    
    public  async Task<ResponseUserProfileJson> Execute()
    {
        var loggedUser = await _loggedUser.Get();
        
        return _mapper.Map<ResponseUserProfileJson>(loggedUser);
    }
}