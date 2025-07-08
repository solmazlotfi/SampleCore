using SampleProject.Core.Domain.Tasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Contract.Repositories
{
    public interface ITaskRepository: IRepository<Tasks>
    {
        Task<List<Tasks>> GetByDate(DateTime date);
    }
}
