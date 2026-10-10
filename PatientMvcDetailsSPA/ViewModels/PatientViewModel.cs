using PatientMvcDetailsSPA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMvcDetailsSPA.ViewModels
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Patient Name is required.")]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "Admission Date is required.")]
        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Mobile Number is required.")]

        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        [Display(Name = "Registration Fee")]
        public decimal RegistrationFee { get; set; }
        [Display(Name = "Enrolled?")]
        public bool IsEnrolled { get; set; }
        [Required(ErrorMessage = "Doctor is required.")]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string DoctorName { get; set; }
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
      
        public int Duration { get; set; }

        [Display(Name = "Upload Picture")]
        public HttpPostedFileBase ProfileFile { get; set; }
        public virtual IList<Doctor> Doctors { get; set; }
        public virtual IList<Patient> Patients { get; set; }
        public virtual IList<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}