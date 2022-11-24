using System.ComponentModel.DataAnnotations;

namespace PatientDoctorApp.Models;

public class Diagnosis: Document
{
    [Required(ErrorMessage = "Please enter patient's condition")]
    public string ConditionStatus { get; set; }
    
    public string Presciptions { get; set; }
    
    public string Remarks { get; set; }
    
} 