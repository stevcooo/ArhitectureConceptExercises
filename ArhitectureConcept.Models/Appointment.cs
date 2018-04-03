using System;

namespace ArhitectureConcept.Models
{
    public class Appointment : BaseModel
    {
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
    }
}
