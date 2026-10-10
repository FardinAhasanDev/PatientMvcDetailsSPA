using PatientMvcDetailsSPA.DAL;
using PatientMvcDetailsSPA.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using PatientMvcDetailsSPA.ViewModels;
using System.IO;
using System.Web;

namespace PatientMvcDetailsSPA.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        PatientDbContext db=new PatientDbContext();
        public ActionResult Index()
        {
            IEnumerable<Patient> patients = db.Patients.Include(c => c.Doctor).Include(c => c.Prescriptions).ToList();
            return View(patients);
        }
        [HttpGet]
        public ActionResult CreatePartial()
        {
            PatientViewModel patient = new PatientViewModel();
            patient.Doctors = db.Doctors.ToList();
            patient.Prescriptions.Add(new Prescription() { PrescriptionId = 1 });
            return PartialView("_CreatePatientPartial", patient);
        }
        [HttpPost]
     
        [ValidateAntiForgeryToken]
        public JsonResult CreatePatient(PatientViewModel vobj)
        {
            if (!ModelState.IsValid)
            {
                vobj.Doctors = db.Doctors.ToList();
                return Json(new { success = false });
            }
            Patient patient = new Patient
            {
                PatientName = vobj.PatientName,
                AdmissionDate = vobj.AdmissionDate,
                MobileNo = vobj.MobileNo,
                RegistrationFee = vobj.RegistrationFee,
                DoctorId = vobj.DoctorId,
                IsEnrolled = vobj.IsEnrolled,
                Prescriptions = vobj.Prescriptions
            };

            if (vobj.ProfileFile != null)
            {
                string uniqueFileName = GetFileName(vobj.ProfileFile);
                patient.ImageUrl = uniqueFileName;
            }
            else
            {
                patient.ImageUrl = "noimage.png";
            }

            db.Patients.Add(patient);
            try
            {
                db.SaveChanges();
                return Json(new { success = true, redirectUrl = Url.Action("Index") });
            }
            catch (Exception ex)
            {
                vobj.Doctors = db.Doctors.ToList();
                return Json(new { success = false });
            }
        }
        private string GetFileName(HttpPostedFileBase file)
        {
            string fileName = "";
            if (file != null)
            {
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file.SaveAs(path);
            }
            return fileName;
        }

        [HttpPost]
        public JsonResult DeletePatient(int id)
        {
            Patient patient = db.Patients.Find(id);
            if (patient != null)
            {
                var modules = db.Prescriptions.Where(s => s.PatientId == id).ToList();
                db.Prescriptions.RemoveRange(modules);
                db.Entry(patient).State = EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, redirectUrl = Url.Action("Index") });
            }
            return Json(new { success = false, message = "Patient not found." });
        }

        public ActionResult EditPartial(int id)
        {
            var patient = db.Patients.Include(c => c.Doctor).Include(c => c.Prescriptions).Where(s => s.PatientId == id).FirstOrDefault();
            if (patient == null)
            {
                return HttpNotFound("Patient Not found");
            }
            var vObj = new PatientViewModel
            {
                PatientName = patient.PatientName,
                PatientId = patient.PatientId,
                AdmissionDate = patient.AdmissionDate,
                MobileNo = patient.MobileNo,
                RegistrationFee = patient.RegistrationFee,
                DoctorId = patient.DoctorId,
                IsEnrolled = patient.IsEnrolled,
                ImageUrl = patient.ImageUrl,
                Prescriptions = patient.Prescriptions.ToList(),
                Doctors = db.Doctors.ToList()
            };
            return PartialView("_EditPatientPartial", vObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditPatient(PatientViewModel vobj, string OldImageUrl)
        {
            if (!ModelState.IsValid)
            {
                vobj.Doctors = db.Doctors.ToList();
                return Json(new { success = false });
            }
            Patient obj = db.Patients
                .Include(a => a.Prescriptions)
                .FirstOrDefault(x => x.PatientId == vobj.PatientId);
            if (obj != null)
            {
                obj.PatientName = vobj.PatientName;
                obj.DoctorId = vobj.DoctorId;
                obj.MobileNo = vobj.MobileNo;
                obj.RegistrationFee = vobj.RegistrationFee;
                obj.IsEnrolled = vobj.IsEnrolled;
                obj.AdmissionDate = vobj.AdmissionDate;
                if (vobj.ProfileFile != null)
                {
                    string uniqueFileName = GetFileName(vobj.ProfileFile);
                    obj.ImageUrl = uniqueFileName;
                }
                else
                {
                    obj.ImageUrl = OldImageUrl;
                }

                var existingModuleIds = obj.Prescriptions.Select(m => m.PrescriptionId).ToList();
                var updatedModuleIds = vobj.Prescriptions.Where(m => m.PrescriptionId > 0).Select(m => m.PrescriptionId).ToList();
                var modulesToRemove = obj.Prescriptions.Where(m => !updatedModuleIds.Contains(m.PrescriptionId)).ToList();
                foreach (var moduleToRemove in modulesToRemove)
                {
                    db.Prescriptions.Remove(moduleToRemove);
                }
                foreach (var item in vobj.Prescriptions)
                {
                    if (item.PrescriptionId > 0)
                    {
                        var existingModule = obj.Prescriptions.FirstOrDefault(m => m.PrescriptionId == item.PrescriptionId);
                        if (existingModule != null)
                        {
                            existingModule.MedicineName = item.MedicineName;
                            existingModule.Duration = item.Duration;
                        }
                    }
                    else
                    {
                        var newModule = new Prescription
                        {
                            PatientId = obj.PatientId,
                            MedicineName = item.MedicineName,
                            Duration = item.Duration
                        };
                        obj.Prescriptions.Add(newModule);
                    }
                }

                try
                {
                    db.SaveChanges();
                    return Json(new { success = true, redirectUrl = Url.Action("Index") });
                }
                catch (Exception ex)
                {
                    
                    vobj.Doctors = db.Doctors.ToList();
                    return Json(new { success = false });
                }
            }
            return Json(new { success = false, errors = new[] { "Patient not found." } });
        }

    }
}