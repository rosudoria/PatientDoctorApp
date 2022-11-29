using System.ComponentModel.DataAnnotations;

namespace PatientDoctorApp.Models;

public class NoteL: Document
{
    [Required(ErrorMessage = "Please enter a note")]
    public string Note { get; set; }
    
}
    