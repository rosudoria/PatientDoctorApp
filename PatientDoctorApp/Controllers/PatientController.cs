using Microsoft.AspNetCore.Mvc;

namespace PatientDoctorApp.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientIndex()
        {
            return View();
        }

        public IActionResult RequestAppointment()
        {
            return View();
        }

        public IActionResult ViewAppointments()
        {
            return View();
        }

        public IActionResult PatientProfile()
        {
            return View();
        }
    }
}
