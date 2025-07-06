using AutoMapper;
using JobPortalBackend.Dtos.request;
using JobPortalBackend.Dtos.response;
using JobPortalBackend.Models;

namespace JobPortalBackend.Map;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<JobDtoRequest , Job>();
        CreateMap<Job , JobDtoResponse >();
    }
}