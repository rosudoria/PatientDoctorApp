using Microsoft.AspNetCore.Mvc;

namespace PatientDoctorApp.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientIndex()
        {
            return View();
        }
    }
}
