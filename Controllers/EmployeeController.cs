// using EmployeeAPI.Data;
// using EmployeeAPI.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace EmployeeAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class EmployeeController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;

//         public EmployeeController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         // ✅ GET: api/employee (Get all employees)
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
//         {
//             return await _context.Employee.ToListAsync();
//         }

//         // ✅ GET: api/employee/{id} (Get a single employee by ID)
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Employee>> GetEmployee(int id)
//         {
//             var employee = await _context.Employee.FindAsync(id);
//             if (employee == null)
//                 return NotFound();
//             return employee;
//         }

//         // ✅ POST: api/employee (Create a new employee)
//         [HttpPost]
//         public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
//         {
//             _context.Employee.Add(employee);
//             await _context.SaveChangesAsync();
//             return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
//         }

//         // ✅ PUT: api/employee/{id} (Update an existing employee)
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
//         {
//             if (id != employee.Id)
//                 return BadRequest();

//             _context.Entry(employee).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         // ✅ DELETE: api/employee/{id} (Delete an employee)
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteEmployee(int id)
//         {
//             var employee = await _context.Employee.FindAsync(id);
//             if (employee == null)
//                 return NotFound();

//             _context.Employee.Remove(employee);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }
