using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientMvcDetailsSPA.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Patients = new HashSet<Patient>();
        }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}