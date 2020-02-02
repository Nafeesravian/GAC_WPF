using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timesheet.core.Base;
using timesheet.core.Singleton;
using timesheet.data.Services;

namespace timesheet.wpf.ViewModel
{
    public class TimeSheetViewModel : BaseViewModel
    {
        private EmployeeService _employeeService;
        private TaskService _taskService;

        public List<timesheet.data.Models.Employee> employees
        {
            get;set;
        }

        public List<timesheet.data.Models.Task> tasks
        {
            get; set;
        }



        public TimeSheetViewModel()
        {
            _employeeService = (EmployeeService)SingletonInstances.GetEmployeeService(typeof(EmployeeService));
            _taskService = (TaskService)SingletonInstances.GetTaskService(typeof(TaskService));

            Task.Run(new Action(OnLoaded));
            
        }

        private async void OnLoaded()
        {
            await Load();
        }

        private async Task Load()
        {
            employees = await this._employeeService.GetEmployees();
            tasks = await this._taskService.GetTasks();
            NotifyPropertyChanged("tasks");
            
        }


    }
}
