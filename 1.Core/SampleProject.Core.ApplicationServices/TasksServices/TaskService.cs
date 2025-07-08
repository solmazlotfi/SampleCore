using SampleProject.Core.Contract.Repositories;
using SampleProject.Core.Domain.Tasks.Entities;
using SampleProject.Core.Domain.Tasks.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.ApplicationServices.TasksServices
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepo;
        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public Task<List<Tasks>> GetAll() => _taskRepo.GetAll();
        public Task<List<Tasks>> GetByDate(DateTime date) =>_taskRepo.GetByDate(date);
        public async Task Add(Tasks task)
        {
            task.Id = Guid.NewGuid();
            task.Status = TasksStatus.New;
            await _taskRepo.Add(task);
        }
        public async Task DoneTask(Guid id)
        {
            var task = await _taskRepo.GetById(id);
            if(task != null)
            {
                task.Status= TasksStatus.Done;
                await _taskRepo.Update(task);
            }
        }
        public async Task CancelTask(Guid id)
        {
            var task = await _taskRepo.GetById(id);
            if (task != null)
            {
                task.Status = TasksStatus.Canceled;
                await _taskRepo.Update(task);
            }
        }
    }
}
