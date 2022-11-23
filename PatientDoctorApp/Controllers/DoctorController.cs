using Microsoft.AspNetCore.Mvc;
using PatientDoctorApp.Models;

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
        
    
        
        [HttpPost]
        public IActionResult SelectedPatientUploadTestReport(string TitleOfTheReport, string Result, string Date)
        {
            Document document = new Document();
            document.DocumentId = "1";
            document.PatientId = "1";
            document.Date = DateTime.Now;
            document.Type = type.TestReport;
            
            document.TestName = TitleOfTheReport;
            document.TestResult = Result;
            document.TestDate = DateTime.Parse(Date);
            document.FilePathTestReport = "Something That i dont know";
            
            int result = document.SaveTestReport();
            if (result>0)
            {
                return View("SelectedPatientLandingPage");
            }
            return View("SelectedPatientUploadDocuments");
        }
        
        [HttpGet]
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
