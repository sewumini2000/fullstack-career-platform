using JobPortalBackend.Models;

namespace JobPortalBackend.Repositories;

public interface IJobRepository
{
    Task<Job> CreateJob(Job job);
    Task<IEnumerable<Job>> GetJobs();
    Task<Job> GetJobById(int id);
    Task<bool> DeleteJob(int id);
    Task<Job> UpdateJob(Job job);
}