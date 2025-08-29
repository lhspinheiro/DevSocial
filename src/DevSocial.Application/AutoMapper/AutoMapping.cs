using AutoMapper;
using DevSocial.Communication.Request;
using DevSocial.Communication.Response;
using DevSocial.Domain.Entitie;

namespace DevSocial.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();

    }

    private void RequestToEntity()
    {
        CreateMap<RequestPostJson, PostEntitie>();
    }

    private void EntityToResponse()
    {
        CreateMap<PostEntitie, ResponsePostJson>();
    }
}