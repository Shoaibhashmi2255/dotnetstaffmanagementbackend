using Microsoft.AspNetCore.Mvc;
using StaffManagementAPI.models;
using StaffManagementAPI.Data; // 👈 Needed for EmployeeContext
using Microsoft.EntityFrameworkCore;

namespace StaffManagementAPI.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = employee.staffId }, employee);
        }


[HttpPut("{id}")]
public async Task<ActionResult<Employee>> Update(int id, Employee employee)
{
    // Check if the employee exists
    var existingEmployee = await _context.Employees.FindAsync(id);
    if (existingEmployee == null)
    {
        return NotFound();
    }

    // Update the employee data only if the new value is provided (not null)
    if (!string.IsNullOrEmpty(employee.fullname))
        existingEmployee.fullname = employee.fullname;

    if (!string.IsNullOrEmpty(employee.Email))
        existingEmployee.Email = employee.Email;

    if (!string.IsNullOrEmpty(employee.PhoneNumber))
        existingEmployee.PhoneNumber = employee.PhoneNumber;

    if (!string.IsNullOrEmpty(employee.Gender))
        existingEmployee.Gender = employee.Gender;

    if (employee.DOB != default(DateTime))
        existingEmployee.DOB = employee.DOB;

    if (employee.hireDate != default(DateTime))
        existingEmployee.hireDate = employee.hireDate;

    if (employee.salary.HasValue)
        existingEmployee.salary = employee.salary;

    if (!string.IsNullOrEmpty(employee.officelocation))
        existingEmployee.officelocation = employee.officelocation;

    if (employee.DepartmentId != 0)
        existingEmployee.DepartmentId = employee.DepartmentId;

    if (!string.IsNullOrEmpty(employee.section))
        existingEmployee.section = employee.section;

    if (!string.IsNullOrEmpty(employee.Religion))
        existingEmployee.Religion = employee.Religion;

    if (!string.IsNullOrEmpty(employee.JobStatus))
        existingEmployee.JobStatus = employee.JobStatus;

    if (employee.levelpolicy.HasValue)
        existingEmployee.levelpolicy = employee.levelpolicy;

    if (!string.IsNullOrEmpty(employee.martialstatus))
        existingEmployee.martialstatus = employee.martialstatus;

if (employee.photo != null && employee.photo.Length > 0)
        existingEmployee.photo = employee.photo;

    if (!string.IsNullOrEmpty(employee.Notes))  // Correct property name
        existingEmployee.Notes = employee.Notes;  // Correct property name

    // Apply other fields if necessary

    try
    {
        // Save changes to the database
        await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        return BadRequest($"Error saving changes: {ex.Message}");
    }

    // Return the updated employee object
    return Ok(existingEmployee);
}





[HttpGet("search")]
public async Task<ActionResult<IEnumerable<Employee>>> Search(
    [FromQuery] string? officeLocation,
    [FromQuery] int? departmentId,
    [FromQuery] int? levelPolicy,
    [FromQuery] string? section,
    [FromQuery] string? religion,
    [FromQuery] string? jobStatus,
    [FromQuery] string? gender,
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10)
{
    var query = _context.Employees.AsQueryable();

    if (!string.IsNullOrEmpty(officeLocation))
        query = query.Where(e => e.officelocation != null && e.officelocation.ToLower() == officeLocation.ToLower());

    if (departmentId.HasValue)
        query = query.Where(e => e.DepartmentId == departmentId.Value);

    if (levelPolicy.HasValue)
        query = query.Where(e => e.levelpolicy == levelPolicy.Value);

    if (!string.IsNullOrEmpty(section))
        query = query.Where(e => e.section != null && e.section.ToLower() == section.ToLower());

    if (!string.IsNullOrEmpty(religion))
        query = query.Where(e => e.Religion != null && e.Religion.ToLower() == religion.ToLower());

    if (!string.IsNullOrEmpty(jobStatus))
        query = query.Where(e => e.JobStatus != null && e.JobStatus.ToLower() == jobStatus.ToLower());

    if (!string.IsNullOrEmpty(gender))
        query = query.Where(e => e.Gender != null && e.Gender.ToLower() == gender.ToLower());

    var totalRecords = await query.CountAsync(); // Total matching records

    var employees = await query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    if (!employees.Any())
        return NotFound("No matching employees found.");

    var response = new
    {
        TotalRecords = totalRecords,
        PageNumber = pageNumber,
        PageSize = pageSize,
        Employees = employees
    };

    return Ok(response);
}


    }

    
}