using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientDoctorApp.Areas.Identity.Data;
using PatientDoctorApp.Data;
using PatientDoctorApp.Models;

namespace PatientDoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        
        private PatientDoctorAppContext _context{get;set;}
        
        public DoctorController(PatientDoctorAppContext context)
        {
            _context = context;
        }
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
            var PatientDoctorAppUsers = _context.Users.OrderBy(m => m.RoleId).ToList();
            var ListOfPatients = new List<PatientDoctorAppUser>();
            
            foreach (var user in PatientDoctorAppUsers)
            {
                if (user.RoleId == 0)
                {
                    ListOfPatients.Add(user);
                }
            }
            /*
                _context.Users.OrderBy(m => m.Role).ToList();
            */
            return View(ListOfPatients);
        }
        
        [HttpGet]
        public IActionResult SelectedPatientLandingPage(string id)
        {
            var DocumentList = _context.Document.OrderBy(m => m.PatientId).ToList();
            var ListOfDocuments = new List<Document>();
            
            foreach (var document in DocumentList)
            {
                if (
                    document.PatientId == id && 
                    document.Type == 3)
                {
                    ListOfDocuments.Add(document);
                }
            }

            var LatestDiagnosticReport = ListOfDocuments.LastOrDefault();
            var PatientDoctorAppUser = _context.Users.Find(id);
            var PatientsDOB = PatientDoctorAppUser.DateOfBirth;
            
            // Data for the view
            string PatientsAge = (DateTime.Now.Year - PatientsDOB.Value.Year).ToString();
            string PatientName = PatientDoctorAppUser.FirstName + " " + PatientDoctorAppUser.LastName;
            string PatientId = PatientDoctorAppUser.Id;
            string Diagnosis = "";
            string Prescription = "";
            string Remarks = "";
            
            if (LatestDiagnosticReport == null)
            {
                Diagnosis = "No diagnosis has been made yet.";
                Prescription = "No prescription has been made yet.";
                Remarks = "No remarks have been made yet.";
            }
            else
            {
                Diagnosis = LatestDiagnosticReport.ConditionStatus;
                Prescription = LatestDiagnosticReport.Prescriptions;
                Remarks = LatestDiagnosticReport.Remarks;
            }
            
            
            // Create a new view model
            var viewModel = new SelectedPatientLandingPageViewModel(PatientName, PatientsAge, Diagnosis, Prescription, Remarks, PatientId);
            
            return View(viewModel);
        }
        /*{
            return View();
        }*/
        
        public IActionResult SelectedPatientUploadDocuments()
        {
            var Url = Request.Query["PatientId"];
            var PatientId = Url.ToString();
            ViewBag.PatientId = PatientId;
            return View();
        }
        
        /// <summary>
        /// This method is used to get the selected patient's Test Report from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectedPatientUploadTestReport()
        {
            var url = Request.Query["PatientId"];
            ViewBag.PatientId = url.ToString();
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
        public IActionResult SelectedPatientUploadTestReport(string id, string TitleOfTheReport, string Result, string Date)
        {
            Document document = new Document();
            document.DocumentId = "1";
            document.PatientId = id;
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
                return View("SelectedPatientUploadDocuments");
            }
            return View("SelectedPatientUploadDocuments");
        }

        /// <summary>
        /// This method is used to post the selected patient's Note to the database
        /// </summary>
        /// <param name="EnterNotesTextArea">a string</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectedPatientUploadNote(string id, string EnterNotesTextArea)
        {
            Document document = new Document();
            document.DocumentId = "2";
            document.PatientId = id;
            document.AppointmentId = "1";
            document.DoctorId = "1";
            document.Date = DateTime.Now;
            document.TestDate = DateTime.Now;
            document.Type = (int) type.Note;
            document.Note = EnterNotesTextArea;
            
            int result = document.SaveDocument();
            if (result>0)
            {
                return View("SelectedPatientUploadDocuments");
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
            var Url = Request.Query["PatientId"];
            ViewBag.PatientId = Url.ToString();
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
        public IActionResult SelectedPatientUploadDiagnosis(string id, string ConditionStatus, string Prescriptions, string Remarks)
        {
            /*var Url = Request.Query["PatientId"];
            var PatientId = HttpContext.Request.Query["PatientId"];*/
            Document document = new Document();
            document.DocumentId = "8";
            document.PatientId = id;
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
                return View("SelectedPatientUploadDocuments");
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
            var Url = Request.Query["PatientId"];
            ViewBag.PatientId = Url.ToString();
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }
    }
    
    public class SelectedPatientLandingPageViewModel
    {
        public string PatientName { get; set; }
        public string PatientsAge { get; set; }
        public string Diagnosis { get; set; }
        public string Prescriptions { get; set; }
        public string Remarks { get; set; }
        
        public string PatientId { get; set; }
        
        public SelectedPatientLandingPageViewModel(string patientName, string patientsAge, 
            string diagnosis, string prescriptions, string remarks, string patientId)
        {
            PatientName = patientName;
            PatientsAge = patientsAge;
            Diagnosis = diagnosis;
            Prescriptions = prescriptions;
            Remarks = remarks;
            PatientId = patientId;
        }
        
    }
    
}
