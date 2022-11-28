using Microsoft.AspNetCore.Mvc;
using PatientDoctorApp.Data;
using PatientDoctorApp.Models;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace PatientDoctorApp.Controllers
{
    public class PatientController : Controller
    {

        private PatientDoctorAppContext _dbContext;

        public PatientController(PatientDoctorAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult PatientIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RequestAppointment()
        {
            //appointments
            ViewBag.AppointmentIds = _dbContext.Appointment.OrderBy(i => i.Id).ToList();
            ViewBag.AppointmentCount = _dbContext.Appointment.OrderBy(i => i.Id).ToList().Count + 1;

            //Patient email
            string email = User.Identity.Name;
            ViewBag.PatientId = _dbContext.Users.Where(u => u.Email.Contains(email)).ToList()[0].Id;

            //Doctors list
            ViewBag.Doctors = _dbContext.Users.Where(u => u.Role.Contains("Doctor")).ToList();

            //Available time slots for appointments
            var listOfTimes = new List<string>()
            {
                "9:00",
                "10:00",
                "11:00",
                "12:00",
                "13:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00"
            };

            ViewBag.TimeSlots = listOfTimes;
            return View("RequestAppointment", new Appointment());
        }

        [HttpPost]
        public IActionResult RequestAppointment(Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Appointment.Add(appointment);
                    _dbContext.SaveChanges();
                    return RedirectToAction("PatientIndex");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("PatientIndex");
        }

        [HttpGet]
        public IActionResult ViewAppointments()
        {
            //Patient email
            string email = User.Identity.Name;
            ViewBag.PatientId = _dbContext.Users.Where(u => u.Email.Contains(email)).ToList()[0].Id;

            //Filter appointments
            ViewBag.Appointments = _dbContext.Appointment.Where(a => a.Email.Contains(email)).OrderBy( a => a.Id).ToList();
            ViewBag.Doctors = _dbContext.Users.Where(u => u.Role.Contains("Doctor")).ToList();
            return View();
        }

        public IActionResult PatientProfile()
        {
            return View();
        }
    }
}
