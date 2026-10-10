using PatientMvcDetailsSPA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientMvcDetailsSPA.DAL
{
    public class PatientDbContext:DbContext
    {
        public PatientDbContext():base("PatientDbContext")
        {}
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<tbl_User> tbl_Users { get; set; }
        public virtual DbSet<tbl_Role> tbl_Roles { get; set; }
        public virtual DbSet<tbl_UserRole> tbl_UserRoles { get; set; }

    }
}