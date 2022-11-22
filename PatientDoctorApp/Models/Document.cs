namespace PatientDoctorApp.Models;

public abstract class Document
{
    public string DocumentId { get; set; }
    public string DoctorId { get; set; }
    /*
    public enum DocumentType { TestReport, Note, Diagnosis }
    */
    public string PatientId { get; set; }
    public string AppointmentId { get; set; }
    public DateTime Date { get; set; }

}