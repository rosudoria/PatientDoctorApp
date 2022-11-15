using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientDoctorApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PatientDoctorApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the DoctorPatientAppUser class
public class PatientDoctorAppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    /*public int GenderId { get; set; }
    public string? GenderName { get; set; }*/


}

