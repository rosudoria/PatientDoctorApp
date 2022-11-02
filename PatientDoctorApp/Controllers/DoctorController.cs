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
        
        public IActionResult SelectedPatientUploadDocuments()
        {
            return View();
        }
        
        public IActionResult SelectedPatientUploadTestReport()
        {
            return View();
        }

        public IActionResult SelectedPatientUploadNote()
        {
            return View();
        }

        public IActionResult SelectedPatientUploadDiagnosis()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
    }
}
