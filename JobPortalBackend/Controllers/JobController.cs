using JobPortalBackend.Dtos.request;
using JobPortalBackend.Dtos.response;
using JobPortalBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace JobPortalBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController: ControllerBase
{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }


    [HttpPost]
    public async Task<ActionResult<JobDtoResponse>> CreateJob(JobDtoRequest jobDto)
    {
        JobDtoResponse jobDtoResponse = await _jobService.CreateJob(jobDto);
        return Ok(jobDtoResponse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDtoResponse>>> GetJobs()
    {
        IEnumerable<JobDtoResponse> jobDtoResponses = await _jobService.GetJobs();
        return Ok(jobDtoResponses);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<JobDtoResponse>> GetJobById( int id)
    {
        
        JobDtoResponse jobDtoResponse = await _jobService.GetJobById(id);
        Console.WriteLine(jobDtoResponse.Id);
        Console.WriteLine(jobDtoResponse);
        if (jobDtoResponse == null)
            return NotFound();
        return Ok(jobDtoResponse);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteJob(int id)
    {
        bool isDeleted = await _jobService.DeleteJob(id);
        if (isDeleted)
            return NoContent();
        return NotFound();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<JobDtoResponse>> UpdateJob(int id , JobDtoRequest jobDto)
    {
        JobDtoResponse jobDtoResponse = await _jobService.UpdateJob(id , jobDto);
        return Ok(jobDtoResponse);
    }


}