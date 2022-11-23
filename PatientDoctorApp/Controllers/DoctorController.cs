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
        
        /// <summary>
        /// This method is used to post the selected patient's Test Report to the database
        /// </summary>
        /// <param name="TitleOfTheReport"> a string</param>
        /// <param name="Result">a string</param>
        /// <param name="Date">a string</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectedPatientUploadTestReport(string TitleOfTheReport, string Result, string Date)
        {
            Document document = new Document();
            document.DocumentId = "1";
            document.PatientId = "1";
            document.AppointmentId = "1";
            document.DoctorId = "1";
            document.Date = DateTime.Now;
            document.Type = (int) type.TestReport;
            document.TestName = TitleOfTheReport;
            document.TestResult = Result;
            document.TestDate = DateTime.Parse(Date);
            document.FilePathTestReport = "Something That i dont know";
            
            int result = document.SaveDocument();
            if (result>0)
            {
                return View("SelectedPatientLandingPage");
            }
            return View("SelectedPatientUploadDocuments");
        }
        
        /// <summary>
        /// This method is used to get the selected patient's Test Report from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectedPatientUploadTestReport()
        {
            return View();
        }
        
        /// <summary>
        /// This method is used to post the selected patient's Note to the database
        /// </summary>
        /// <param name="EnterNotesTextArea">a string</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectedPatientUploadNote(string EnterNotesTextArea)
        {
            Document document = new Document();
            document.DocumentId = "2";
            document.PatientId = "1";
            document.AppointmentId = "1";
            document.DoctorId = "1";
            document.Date = DateTime.Now;
            document.TestDate = DateTime.Now;
            document.Type = (int) type.Note;
            document.Note = EnterNotesTextArea;
            
            int result = document.SaveDocument();
            if (result>0)
            {
                return View("SelectedPatientLandingPage");
            } 
            return View("SelectedPatientUploadDocuments");
        }
        
        /// <summary>
        /// This method is used to get the selected patient's Diagnosis from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectedPatientUploadNote()
        {
            return View();
        }

        /// <summary>
        /// This method is used to post the selected patient's Diagnosis to the database
        /// </summary>
        /// <param name="ConditionStatus">a string</param>
        /// <param name="Prescriptions">a string</param>
        /// <param name="Remarks">a string</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectedPatientUploadDiagnosis(string ConditionStatus, string Prescriptions, string Remarks)
        {
            Document document = new Document();
            document.DocumentId = "3";
            document.PatientId = "1";
            document.AppointmentId = "1";
            document.DoctorId = "1";
            document.Date = DateTime.Now;
            document.TestDate = DateTime.Now;
            document.Type = (int) type.Diagnosis;
            document.ConditionStatus = ConditionStatus;
            document.Prescriptions = Prescriptions;
            document.Remarks = Remarks;
            
            int result = document.SaveDocument();
            if (result>0)
            {
                return View("SelectedPatientLandingPage");
            }
            return View("SelectedPatientUploadDocuments");

        }
        
        
        /// <summary>
        /// This method is used to get the selected patient's Note from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
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
