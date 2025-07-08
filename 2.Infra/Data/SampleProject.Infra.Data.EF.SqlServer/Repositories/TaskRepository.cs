using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Contract.Repositories;
using SampleProject.Core.Domain.Tasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Infra.Data.EF.SqlServer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;
        public TaskRepository(TaskDbContext context) => _context = context;
        public async Task Add(Tasks entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Tasks entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tasks>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<List<Tasks>> GetByDate(DateTime date)
        {
            return await _context.Tasks.Where(x => x.Date.Date == date).ToListAsync();
        }

        public async Task<Tasks?> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task Update(Tasks entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
