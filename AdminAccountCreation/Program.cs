using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAccountCreation
{
    class Program
    {
        static void Main(string[] args)
        {

            ImusCityHallEntities db = new ImusCityHallEntities();
            Employee employee = new Employee();
            employee.EmployeeNo = "0000001";

            if (!db.Employees.Any(m => m.EmployeeNo == employee.EmployeeNo))
            {
                employee.FirstName = "HalconTech";
                employee.LastName = "HalconTech";
                employee.PrimaryEmail = "HalconTech2019@gmail.com";
                db.Employees.Add(employee);

                AspNetRole roles = new AspNetRole();
                roles.Id = "1";
                roles.Name = "Administrator";
                db.AspNetRoles.Add(roles);
                db.SaveChanges();

                db = new ImusCityHallEntities();
                AspNetUser aspuser = new AspNetUser();
                AspNetUserRole asproleuser = new AspNetUserRole();
                aspuser.Id = Guid.NewGuid().ToString();
                aspuser.UserName = employee.EmployeeNo;
                aspuser.Email = employee.PrimaryEmail;
                aspuser.EmailConfirmed = true;
                aspuser.PhoneNumberConfirmed = false;
                aspuser.TwoFactorEnabled = false;
                aspuser.LockoutEnabled = true;
                aspuser.AccessFailedCount = 0;
                aspuser.SecurityStamp = Guid.NewGuid().ToString();
                var passwordHasher = new Microsoft.AspNet.Identity.PasswordHasher();
                aspuser.PasswordHash = passwordHasher.HashPassword("Pa$$w0rd");
                var adduser = db.AspNetUsers.Add(aspuser);
                asproleuser.UserId = adduser.Id;
                asproleuser.RoleId = "1";
                db.AspNetUserRoles.Add(asproleuser);




                db.SaveChanges();
                Console.WriteLine("Admin account created succesfully");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Account is already created");
                Console.ReadLine();
            }
           
        }
    }
}
