using JobPortalBackend.Dtos.request;
using JobPortalBackend.Dtos.response;

namespace JobPortalBackend.Services;

public interface IJobService
{
    Task<JobDtoResponse> CreateJob(JobDtoRequest jobDto);
    Task<IEnumerable<JobDtoResponse>> GetJobs();
    Task<JobDtoResponse> GetJobById(int id);
    Task<bool> DeleteJob(int id);
    Task<JobDtoResponse> UpdateJob(int id, JobDtoRequest jobDto);
}