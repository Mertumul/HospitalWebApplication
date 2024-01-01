using HospitalWebApplication.Areas.Identity.Data;
using HospitalWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApplication.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientApiController : ControllerBase
	{
		private readonly HospitalWebApplicationContext _context;

		public PatientApiController(HospitalWebApplicationContext context)
		{
			_context = context;
		}

		// GET: api/PatientApiController
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetPatients()
		{
			// Filter users by role (in this case, patients)
			var patients = await _context.Users
				.Where(u => u.IsDoctor == false) // Assuming IsDoctor is used to differentiate patients
				.ToListAsync();

			return Ok(patients);
		}

		// GET: api/PatientApiController/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ApplicationUser>> GetPatient(string id)
		{
			var patient = await _context.Users.FindAsync(id);

			if (patient == null)
			{
				return NotFound();
			}

			return Ok(patient);
		}
		// POST: api/PatientApiController

		[HttpDelete("{id}")]
		public async Task<ActionResult<ApplicationUser>> DeletePatient(string id)
		{
			var patient = await _context.Users.FindAsync(id);
			if (patient == null)
			{
				return NotFound();
			}

			// Manually delete related appointments
			var relatedAppointments = _context.Appointment.Where(a => a.PatientId == id);
			_context.Appointment.RemoveRange(relatedAppointments);

			_context.Users.Remove(patient);
			await _context.SaveChangesAsync();

			return Ok(patient);
		}

		[HttpPut("{id}")]
		public IActionResult UpdatePatient(int id, [FromBody] ApplicationUser updatedPatient)
		{
			// Check if the patient with the given id exists
			var existingPatient = _context.Users.Find(id);
			if (existingPatient == null)
			{
				return NotFound(); // Patient not found
			}

			// Update the properties of the existing patient
			existingPatient.FirstName = updatedPatient.FirstName;
			existingPatient.LastName = updatedPatient.LastName;
			existingPatient.Gender = updatedPatient.Gender;
			existingPatient.Address = updatedPatient.Address;
			existingPatient.DOB = updatedPatient.DOB;
			existingPatient.Specialist = updatedPatient.Specialist;
			existingPatient.IsDoctor = updatedPatient.IsDoctor;
			existingPatient.AppUserDepartmentId = updatedPatient.AppUserDepartmentId;

			// Save changes to the database
			_context.SaveChanges();

			return Ok(existingPatient); // Return the updated patient
		}


		// Other CRUD actions (POST, PUT) can be implemented based on your requirements
	}
}
