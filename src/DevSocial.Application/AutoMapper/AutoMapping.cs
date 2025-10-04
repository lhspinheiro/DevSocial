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
        CreateMap<RequestToReplyJson, ReplyEntitie>();
        CreateMap<RequestRegisterUserJson, UserEntitie>();
        
    }

    private void EntityToResponse()
    {
        CreateMap<PostEntitie, ResponsePostJson>();
        CreateMap<ReplyEntitie, ResponseReplyJSon>()
            .ForMember(dest => dest.Post, 
                opt => opt.MapFrom(src => src.Post.Post))
            .ForMember(dest => dest.Reply, 
                opt => opt.MapFrom(src => src.Reply));
        
        CreateMap<ReplyEntitie, ResponseListReplyJson>()
            .ForMember(dest => dest.Reply, 
                opt => opt.MapFrom(src => new List<ReplyEntitie> {src}));

        CreateMap<UserEntitie, ResponseRegisteredUserJson>();
    }
}