using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientDoctorApp.Areas.Identity.Data;
using PatientDoctorApp.Data;
using PatientDoctorApp.Models;

namespace PatientDoctorApp.Controllers
{
    // This controller is used to display various stats related to the patient on doctor's dashboard
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
        
        /// <summary>
        /// This method is used to display the list of patients in the doctor's dashboard.
        /// </summary>
        /// <returns>
        /// The view of the list of patients.
        /// </returns>
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
        
        /// <summary>
        /// This is a get method to display the patient's details on selecting a patient from the list.
        /// </summary>
        /// <param name="id">a string: The patientID</param>
        /// <returns>
        /// The view of the patient's details.
        /// </returns>
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
        
        /// <summary>
        /// This is the get method to display the type of documents to be uploaded.
        /// </summary>
        /// <returns>
        /// The view of the Document Select component.
        /// </returns>
        [HttpGet]
        public IActionResult SelectedPatientUploadDocuments()
        {
            var Url = Request.Query["PatientId"];
            var PatientId = Url.ToString();
            ViewBag.PatientId = PatientId;
            PatientDoctorAppUser PatientDoctorAppUser = _context.Users.Find(PatientId);
            string PatientName = PatientDoctorAppUser.FirstName + " " + PatientDoctorAppUser.LastName;
            string PatientAge = (DateTime.Now.Year - PatientDoctorAppUser.DateOfBirth.Value.Year).ToString();
            
            var ListOfDocuments = _context.Document.OrderBy(m => m.PatientId).ToList();
            var PatientsTestReports = new List<Document>();
            Document PatientsLatestTestReport;
            
            var PatientsNotes = new List<Document>();
            Document PatientsLatestNote;
            
            var PatientsDiagnosis = new List<Document>();
            Document PatientsLatestDiagnosis;

            foreach (var doc in ListOfDocuments)
            {
                if (doc.Type == 1 && doc.PatientId == PatientId)
                {
                    PatientsTestReports.Add(doc);
                }
                else if (doc.Type == 2 && doc.PatientId == PatientId)
                {
                    PatientsNotes.Add(doc);
                }
                else if (doc.Type == 3 && doc.PatientId == PatientId)
                {
                    PatientsDiagnosis.Add(doc);
                }
            }
            
            int lastTestReportIndex = PatientsTestReports.Count - 1;
            int lastNoteIndex = PatientsNotes.Count - 1;
            int lastDiagnosisIndex = PatientsDiagnosis.Count - 1;
            
            if (lastTestReportIndex >= 0)
            {
                PatientsLatestTestReport = PatientsTestReports[lastTestReportIndex];
            }
            else
            {
                PatientsLatestTestReport = null;
            }
            
            if (lastNoteIndex >= 0)
            {
                PatientsLatestNote = PatientsNotes[lastNoteIndex];
            }
            else
            {
                PatientsLatestNote = null;
            }
            
            if (lastDiagnosisIndex >= 0)
            {
                PatientsLatestDiagnosis = PatientsDiagnosis[lastDiagnosisIndex];
            }
            else
            {
                PatientsLatestDiagnosis = null;
            }
            
            var viewModel = new SelectedPatientUploadDocumentsViewModel(PatientName, PatientAge, PatientsLatestTestReport, PatientsLatestNote, PatientsLatestDiagnosis);

            return View(viewModel);
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
            var ListOfAllDocuments = _context.Document.OrderBy(m=>m.DocumentId).ToList();
            Document document = new Document();
            if (ListOfAllDocuments.Count == 0)
            {
                document.DocumentId = 1;
            }
            else
            {
                document.DocumentId = ListOfAllDocuments.LastOrDefault()!.DocumentId + 1;
            }
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
                return RedirectToAction("SelectedPatientUploadDocuments", "Doctor", new {PatientId = id});
                /*
                return View("SelectedPatientUploadDocuments", new{PatientId = id});
            */
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
            var ListOfAllDocuments = _context.Document.OrderBy(m=>m.DocumentId).ToList();
            /*if (ListOfAllDocuments.Count == 0)
            {
                document.DocumentId = 1;
            }
            else
            {
                document.DocumentId = ListOfAllDocuments.LastOrDefault()!.DocumentId + 1;
            }*/
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
                return RedirectToAction("SelectedPatientUploadDocuments", "Doctor", new {PatientId = id});
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
            var ListOfAllDocuments = _context.Document.OrderBy(m=>m.DocumentId).ToList();
            if (ListOfAllDocuments.Count == 0)
            {
                document.DocumentId = 1;
            }
            else
            {
                document.DocumentId = ListOfAllDocuments.LastOrDefault()!.DocumentId + 1;
            }
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
                return RedirectToAction("SelectedPatientUploadDocuments", "Doctor", new {PatientId = id});
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
        
        /// <summary>
        /// This method is used to display all the documents of the selected patient from the DB.
        /// </summary>
        /// <returns>
        /// The view of all the documents of the selected patient.
        /// </returns>
        public IActionResult SelectedPatientViewDocuments()
        {
            var Url = Request.Query["PatientId"];
            var PatientId = Url.ToString();
            ViewBag.PatientId = PatientId;
            var DocumentList = _context.Document.OrderBy(d => d.PatientId).ToList();
            var PatientDocumentListNotes = new List<Document>();
            var PatientDocumentListTestReport = new List<Document>();
            var PatientDocumentListDiagnosis = new List<Document>();
            foreach (var PatientDocument in DocumentList)
            {
                if (PatientDocument.PatientId == ViewBag.PatientId)
                {
                    if (PatientDocument.Type == 3)
                    {
                        PatientDocumentListDiagnosis.Add(PatientDocument);
                    }
                    else if (PatientDocument.Type == 1)
                    {
                        PatientDocumentListTestReport.Add(PatientDocument);
                    }
                    else if (PatientDocument.Type == 2)
                    {
                        PatientDocumentListNotes.Add(PatientDocument);
                    }
                }

            }
            var SelectedPatientViewDocumentModel = new SelectedPatientViewDocumentsModel(PatientDocumentListDiagnosis, PatientDocumentListTestReport, PatientDocumentListNotes);
            return View(SelectedPatientViewDocumentModel);
        }
        
    }
    
    /// <summary>
    /// This is the View model class for the SelectedPatientLandingPageViewModel method.
    /// </summary>
    public class SelectedPatientLandingPageViewModel
    {
        /// <summary>
        /// Name of the patient.
        /// </summary>
        public string PatientName { get; set; }
        
        /// <summary>
        /// Age of the patient.
        /// </summary>
        public string PatientsAge { get; set; }
        
        /// <summary>
        /// Diagnosis of the patient.
        /// </summary>
        public string Diagnosis { get; set; }
        
        /// <summary>
        /// Prescriptions of the patient.
        /// </summary>
        public string Prescriptions { get; set; }
        
        /// <summary>
        /// These should be any remarks made by the doctor for the patient.
        /// </summary>
        public string Remarks { get; set; }
        
        /// <summary>
        /// Patient's ID.
        /// </summary>
        public string PatientId { get; set; }
        
        /// <summary>
        /// This is the constructor for the SelectedPatientLandingPageViewModel class.
        /// </summary>
        /// <param name="patientName"></param>
        /// <param name="patientsAge"></param>
        /// <param name="diagnosis"></param>
        /// <param name="prescriptions"></param>
        /// <param name="remarks"></param>
        /// <param name="patientId"></param>
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

    /// <summary>
    /// This is the View model class for the SelectedPatientViewDocuments method.
    /// </summary>
    public class SelectedPatientViewDocumentsModel
    {
        /// <summary>
        /// List of all the diagnosis of the patient.
        /// </summary>
        public List<Document> PatientsDiagnosis { get; set; }
        
        /// <summary>
        /// List of all the test reports of the patient.
        /// </summary>
        public List<Document> PatientsTestReports { get; set; }
        
        /// <summary>
        /// List of all the notes of the patient made by the doctor.
        /// </summary>
        public List<Document> PatientsNotes { get; set; }
        
        /// <summary>
        /// This is the constructor for the SelectedPatientViewDocumentsModel class.
        /// </summary>
        /// <param name="patientsDiagnosis"></param>
        /// <param name="patientsTestReports"></param>
        /// <param name="patientsNotes"></param>
        public SelectedPatientViewDocumentsModel(List<Document> patientsDiagnosis, List<Document> patientsTestReports, List<Document> patientsNotes)
        {
            PatientsDiagnosis = patientsDiagnosis;
            PatientsTestReports = patientsTestReports;
            PatientsNotes = patientsNotes;
        }
    }

    public class SelectedPatientUploadDocumentsViewModel
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public Document TestReport { get; set; }
        public Document Diagnosis { get; set; }
        public Document Notes { get; set; }
        
        public SelectedPatientUploadDocumentsViewModel(string name, string age, Document testReport, Document diagnosis, Document notes)
        {
            Name = name;
            Age = age;
            TestReport = testReport;
            Diagnosis = diagnosis;
            Notes = notes;
        }
    }
    
}
