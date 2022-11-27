using System.ComponentModel.DataAnnotations;

namespace PatientDoctorApp.Models
{
    public class Appointment
    {
        public string Details { get; set; }

        [Required(ErrorMessage = "Reason for visting is required")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Unique ID")]
        public string _Id { get; set; }

        [Required(ErrorMessage = "Patient ID required")]
        public string PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID required")]
        public string DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment type required")]
        public string AppointmentType { get; set; }

        [Required(ErrorMessage = "Status required")]
        public string Status { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }
    }

    enum StatusTypes
    {
        PENDING,
        ACCEPTED,
        CANCELLED,
        COMPLEETED
    }

    enum AppointmentType
    {
        INPERSON,
        ONLINE
    }

    enum Reasons
    {
        FOLLOWUP,
        RESULTS,
        OTHER
    }
}
