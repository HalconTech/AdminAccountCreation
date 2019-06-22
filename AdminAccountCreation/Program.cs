using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAccountCreation
{
    class Program
    {
        public static void SubmoduleCreation()
        {
            //Submodule Creation
            ImusCityHallEntities db = new ImusCityHallEntities();
            
            StringDictionary dictsubModule = new StringDictionary();
            dictsubModule.Add("Check Disbursement", "CDS");
            dictsubModule.Add("Employee Management", "EMP");
            dictsubModule.Add("Customer", "CUST");
            dictsubModule.Add("Department", "DEPT");
            dictsubModule.Add("Division", "DIV");
            dictsubModule.Add("Identification Card", "ID");
            dictsubModule.Add("User Access", "UA");

            foreach (DictionaryEntry entry in dictsubModule)
            {
                string moduleName = entry.Key.ToString();
                moduleName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(moduleName.ToLower());
                SubModule subModule = new SubModule()
                {
                    Name = moduleName,
                    Acronym = entry.Value.ToString()
                };
                db.SubModules.Add(subModule);
                db.SaveChanges();        
            }
        }

        public static void SetUserAccess(int id)
        {
            ImusCityHallEntities db = new ImusCityHallEntities();
            List<SubModule> submoduleList = db.SubModules.ToList();
            foreach(var subModule in submoduleList)
            {
                SubModuleUser subModuleUser = new SubModuleUser()
                {
                    EmployeeID = id,
                    SubModuleID = subModule.SubModuleID
                };
                db.SubModuleUsers.Add(subModuleUser);
                db.SaveChanges();
            }

        }
        static void Main(string[] args)
        {
            ImusCityHallEntities db = new ImusCityHallEntities();
            Employee employee = new Employee();
            employee.EmployeeNo = "0000001";

            if (!db.Employees.Any(m => m.EmployeeNo == employee.EmployeeNo))
            {
                //Admin Creation
                employee.FirstName = "HalconTech";
                employee.LastName = "HalconTech";
                employee.PrimaryEmail = "HalconTech2019@gmail.com";
                employee.IsAdmin = true;
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
                SubmoduleCreation();
                SetUserAccess(employee.EmployeeID);
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
