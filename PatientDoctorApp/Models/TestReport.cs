using System.ComponentModel.DataAnnotations;

namespace PatientDoctorApp.Models;

public class TestReport: Document
{
    [Required(ErrorMessage = "Test Name is required")]
    public string TestName { get; set; }
    
    [Required(ErrorMessage = "Test Date is required")]
    public DateTime TestDate { get; set; }
    
    [Required(ErrorMessage = "Test Result is required")]
    public string TestResult { get; set; }
    
    [Required(ErrorMessage = "Test Report File is required")]
    public string FilePath { get; set; }
}
