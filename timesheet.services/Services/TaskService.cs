using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using timesheet.data.Contracts;
using timesheet.data.Models;

namespace timesheet.data.Services
{
    public class TaskService : IEmployeeService, ITaskService
    {
        private string _baseurl = "";
        public TaskService()
        {
            _baseurl = ConfigurationManager.AppSettings["baseUrl"];
        }
        public async Task<List<Employee>> GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                List<Employee> employees = new List<Employee>();
                HttpResponseMessage response = await client.GetAsync(_baseurl+"/employee/getall");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    employees= JsonConvert.DeserializeObject<List<Employee>>(json);
                }
                return employees;
            }
        }

        public async Task<List<timesheet.data.Models.Task>> GetTasks()
        {
            using (HttpClient client = new HttpClient())
            {
                List<timesheet.data.Models.Task> tasks = new List<timesheet.data.Models.Task>();
                HttpResponseMessage response = await client.GetAsync(_baseurl + "/task/getall");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    tasks = JsonConvert.DeserializeObject<List<timesheet.data.Models.Task>>(json);
                }
                return tasks;
            }
        }


    }
}
