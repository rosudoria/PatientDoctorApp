using PatientDoctorApp.Areas.Identity.Data;
using PatientDoctorApp.Data;

namespace PatientDoctorApp.Models
{
    public class RequestAppointment
    {
        public string? PatientId { get; set; }
        public List<PatientDoctorAppUser>? DoctorList { get; set; }

        public TimeSlots? TimeSlots { get; set; }

        public Appointment? Appointment { get; set; }
    }
}
