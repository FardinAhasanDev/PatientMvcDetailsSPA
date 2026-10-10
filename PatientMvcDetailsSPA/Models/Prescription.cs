namespace PatientMvcDetailsSPA.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public string MedicineName { get; set; }
        public int Duration { get; set; }
        public virtual Patient Patient { get; set; }
    }
}