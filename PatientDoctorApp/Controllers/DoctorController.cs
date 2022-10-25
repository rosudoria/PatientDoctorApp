using Microsoft.AspNetCore.Mvc;

namespace PatientDoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorIndex()
        {
            return View();
        }
    }
}
