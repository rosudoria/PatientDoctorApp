using Microsoft.AspNetCore.Mvc;

namespace PatientDoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorIndex()
        {
            return View();
        }
        
        public IActionResult DoctorProfile()
        {
            return View();
        }
        
        public IActionResult SelectPatient()
        {
            return View();
        }
        
        public IActionResult SelectedPatientLandingPage()
        {
            return View();
        }
    }
}
