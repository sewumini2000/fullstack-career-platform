using AutoMapper;
using JobPortalBackend.Dtos.request;
using JobPortalBackend.Dtos.response;
using JobPortalBackend.Models;
using JobPortalBackend.Repositories;

namespace JobPortalBackend.Services.impl;

public class JobServiceImpl: IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;
    public JobServiceImpl(IJobRepository jobRepository , IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<JobDtoResponse> CreateJob(JobDtoRequest jobDto)
    {
        Job job = _mapper.Map<Job>(jobDto);
        Job createdJob = await _jobRepository.CreateJob(job);
        return _mapper.Map<JobDtoResponse>(createdJob);
    }

    public async Task<IEnumerable<JobDtoResponse>> GetJobs()
    {
        IEnumerable<Job> jobs = await _jobRepository.GetJobs();
        return _mapper.Map<IEnumerable<JobDtoResponse>>(jobs);
    }

    public async Task<JobDtoResponse> GetJobById(int id)
    {
        Job job = await _jobRepository.GetJobById(id);
        return _mapper.Map<JobDtoResponse>(job);
    }

    public async Task<bool> DeleteJob(int id)
    {
        bool isDeleted = await _jobRepository.DeleteJob(id);
        return isDeleted;
    }

    public async Task<JobDtoResponse> UpdateJob(int id, JobDtoRequest jobDto)
    {
        Job job = await _jobRepository.GetJobById(id);
        if(job == null)
            throw new KeyNotFoundException($"Job with id: {id} was not found");
        
        job.Title = jobDto.Title;
        job.Description = jobDto.Description;
        job.Company = jobDto.Company;
        job.Location = jobDto.Location;

        Job afterUpdated = await _jobRepository.UpdateJob(job);
        return _mapper.Map<JobDtoResponse>(afterUpdated);
    }
}