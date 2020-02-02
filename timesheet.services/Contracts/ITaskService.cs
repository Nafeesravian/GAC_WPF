using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.data.Models;

namespace timesheet.data.Contracts
{
    public interface ITaskService
    {
        Task<List<timesheet.data.Models.Task>> GetTasks();
    }
}
