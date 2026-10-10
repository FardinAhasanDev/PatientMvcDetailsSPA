using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientMvcDetailsSPA.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<Prescription>();
        }
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        [Required, Display(Name = "Admission Date"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] 
        public System.DateTime AdmissionDate { get; set; }
        public string MobileNo { get; set; }
        public decimal RegistrationFee { get; set; }
        public bool IsEnrolled { get; set; }
        public int DoctorId { get; set; }
        public string ImageUrl { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}