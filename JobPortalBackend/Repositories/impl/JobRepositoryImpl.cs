using JobPortalBackend.Data;
using JobPortalBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalBackend.Repositories.impl;

public class JobRepositoryImpl: IJobRepository
{
    private readonly AppDbContext _context;
    public JobRepositoryImpl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Job> CreateJob(Job job)
    {
        await _context.Jobs.AddAsync(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<IEnumerable<Job>> GetJobs()
    {
        return await _context.Jobs.ToListAsync();
    }

    public async Task<Job> GetJobById(int id)
    {
        return await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task<bool> DeleteJob(int id)
    {
        Job job = await _context.Jobs.FindAsync(id);
        if (job != null)
        {
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;

    }

    public async Task<Job> UpdateJob(Job job)
    {
        _context.Update(job);
        await _context.SaveChangesAsync();
        return job;
    }
}