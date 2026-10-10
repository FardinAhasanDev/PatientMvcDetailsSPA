namespace PatientMvcDetailsSPA.Migrations
{
    using PatientMvcDetailsSPA.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatientMvcDetailsSPA.DAL.PatientDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PatientMvcDetailsSPA.DAL.PatientDbContext context)
        {
            var doctors = new List<Doctor>
            {
                new Doctor {DoctorName="Dr. Ahsan Kabir" },
                new Doctor {DoctorName="Dr. Nusrat Jahan" },
                new Doctor {DoctorName="Dr. Rafiqul Islam" }
            };
            doctors.ForEach(s => context.Doctors.AddOrUpdate(p => p.DoctorName, s));
            context.SaveChanges();

            context.tbl_Roles.AddOrUpdate(r => r.RoleId,
                new tbl_Role { RoleId = 1, RoleName = "Admin" },
                new tbl_Role { RoleId = 2, RoleName = "User" }
                );
            context.tbl_Users.AddOrUpdate(u => u.UserId,
                new tbl_User { UserId = 1, UserName = "admin", Password = "admin123" }
                );
            context.tbl_UserRoles.AddOrUpdate(ur => ur.Id,
                new tbl_UserRole { Id = 1, UserId = 1, RoleId = 1 }
                );
            context.SaveChanges();
        }
    }
}
