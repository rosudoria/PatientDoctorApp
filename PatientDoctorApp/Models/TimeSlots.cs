﻿namespace PatientDoctorApp.Models
{
    public class TimeSlots
    {
        public List<string> Times { get; set; }

        public TimeSlots()
        {
            var listOfTimes = new List<string>()
            {
                "9:00",
                "10:00",
                "11:00",
                "12:00",
                "13:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00"
            };

            this.Times = listOfTimes;
        }
    }
}
