using EMS.Data;
using EMS.Models;
using EMS.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

            return RedirectToAction("List", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.Employee.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee viewModel)
        {
            var employee = await dbContext.Employee.FindAsync(viewModel.Id);

            if (employee is not null)
            {
                employee.FirstName = viewModel.FirstName;
                employee.LastName = viewModel.LastName;
                employee.BirthDay = viewModel.BirthDay;
                employee.Email = viewModel.Email;
                employee.Phone = viewModel.Phone;
                employee.Departments = viewModel.Departments;

                await dbContext.SaveChangesAsync();

            }

            return RedirectToAction("List", "Employee");
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(Employee viewModel)
        {
            var employee = await dbContext.Employee
                .AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (employee is not null)
            {
                dbContext.Employee.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Employee");
        }
    }
}
