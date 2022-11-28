﻿using System.ComponentModel.DataAnnotations;

namespace PatientDoctorApp.Models
{
    public class Appointment
    {
        public string? MSPNumber { get; set; }
        public string? Details { get; set; }

        [Required(ErrorMessage = "Reason for visting is required")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Unique ID")]
        public string Id { get; set; }

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

        public DateTime Date { get; set; }

        public string TimeSlot { get; set; }
    }

    public enum StatusTypes
    {
        PENDING,
        ACCEPTED,
        CANCELLED,
        COMPLEETED
    }

    public enum AppointmentType
    {
        INPERSON,
        ONLINE
    }

    public enum Reasons
    {
        FOLLOWUP,
        RESULTS,
        OTHER
    }
}
