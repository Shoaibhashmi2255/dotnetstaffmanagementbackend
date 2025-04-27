using Microsoft.AspNetCore.Mvc;
using StaffManagementAPI.models;
using StaffManagementAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace StaffManagementAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DepartmentController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department == null ? NotFound() : Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Add(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentID }, department);
        }
    }
}