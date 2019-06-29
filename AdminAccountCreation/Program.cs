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

        public static void CreateSecurityQuestion()
        {
            ImusCityHallEntities db = new ImusCityHallEntities();
            StringDictionary securityQuestions = new StringDictionary();
            securityQuestions.Add("1", "What was your childhood nickname?");
            securityQuestions.Add("2", "In what city did you meet your spouse/significant other?");
            securityQuestions.Add("3", "What is the name of your favorite childhood friend?");
            securityQuestions.Add("4", "What street did you live on in third grade?");
            securityQuestions.Add("5", "What is your oldest sibling’s birthday month and year? (e.g., January 1900)");
            securityQuestions.Add("6", "What is the middle name of your youngest child?");
            securityQuestions.Add("7", "What is your oldest sibling middle name?");
            securityQuestions.Add("8", "What school did you attend for sixth grade?");
            securityQuestions.Add("9", "What was your childhood phone number including area code? (e.g., 000-000-0000)");
            securityQuestions.Add("10", "What is your oldest cousin first and last name?");
            securityQuestions.Add("11", "What was the name of your first stuffed animal?");
            securityQuestions.Add("12", "In what city or town did your mother and father meet?");
            securityQuestions.Add("13", "Where were you when you had your first kiss?");
            securityQuestions.Add("14", "What is the first name of the boy or girl that you first kissed?");
            securityQuestions.Add("15", "What was the last name of your third grade teacher?");
            securityQuestions.Add("16", "In what city does your nearest sibling live?");
            securityQuestions.Add("17", "What is your youngest brother’s birthday month and year? (e.g., January 1900)");
            securityQuestions.Add("18", "What is your maternal grandmother maiden name?");

            foreach (DictionaryEntry entry in securityQuestions)
            {
                SecurityQuestionBank securityQuestion = new SecurityQuestionBank
                {
                    Question = entry.Value.ToString()
                };
                db.SecurityQuestionBanks.Add(securityQuestion);
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
        public static int SuperAdminCreation()
        {
            ImusCityHallEntities db = new ImusCityHallEntities();
            Employee employee = new Employee();
            employee.EmployeeNo = "123456";
            employee.FirstName = "HalconTech";
            employee.LastName = "HalconTech";
            employee.PrimaryEmail = "HalconTech2019@gmail.com";
            employee.IsAdmin = true;
            db.Employees.Add(employee);

            AspNetRole roles = new AspNetRole();
            roles.Id = "1";
            roles.Name = "Super Administrator";
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


            return employee.EmployeeID;

        }
        //public static void GenerateLicense(DateTime expiredDate, bool isActive, bool isDemo)
        //{
        //    ImusCityHallEntities db = new ImusCityHallEntities();
        //    StringDictionary licenseCodes = new StringDictionary();
        //    licenseCodes.Add("1", "BDBR5VUAYDQD9FWJV9VSCZJNWV87UN");
        //    licenseCodes.Add("1", "KKFGXKZCSNBZBBKR24SFJJ3PEUAXC7");
        //    licenseCodes.Add("1", "RWDGUYBSE4XT9SRH6LKNSRWUY6LLGR");
        //    licenseCodes.Add("1", "NSBNT984V82SGTN342NBKHUYNEGB4C");
        //    licenseCodes.Add("1", "7Y2DRE3XCF9R2BQ36W252YFCGRBUXR");

        //    LicensingCode licenseCode = new LicensingCode();

        //}
        static void Main(string[] args)
        {
         
            ImusCityHallEntities db = new ImusCityHallEntities();
            Employee employee = new Employee();
            employee.EmployeeNo = "0000001";

            if (!db.Employees.Any(m => m.EmployeeNo == employee.EmployeeNo))
            {
                int superAdmin = SuperAdminCreation();
                //Admin Creation
                employee.FirstName = "HalconTech";
                employee.LastName = "HalconTech";
                employee.PrimaryEmail = "HalconTech2019@gmail.com";
                employee.IsAdmin = true;
                db.Employees.Add(employee);

                AspNetRole roles = new AspNetRole();
                roles.Id = "2";
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
                asproleuser.RoleId = "2";
                db.AspNetUserRoles.Add(asproleuser);
                db.SaveChanges();


                SubmoduleCreation();
                CreateSecurityQuestion();
                SetUserAccess(employee.EmployeeID);
                SetUserAccess(superAdmin);
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
