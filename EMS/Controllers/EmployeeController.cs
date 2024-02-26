using EMS.Data;
using EMS.Models;
using EMS.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Personal/Index
        public async Task<IActionResult> List()
        {
            var personals = await dbContext.Employee.ToListAsync();
            return View(personals);
        }

        //GET: Personal/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Personal/Add
        [HttpPost]
        public async Task<IActionResult> Add(AddPersonalViewModel viewModel)
        {
            var employee = new Employee
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                BirthDay = viewModel.BirthDay,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Departments = viewModel.Department,
            };

            await dbContext.Employee.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
