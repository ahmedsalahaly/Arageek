using Arageek.Consts;
using Arageek.Models;
using Arageek.Models.Categories;
using Arageek.Models.Users;
using Arageek.Repository;
using Arageek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.ConsoleService
{
    public static class ConsoleService
    {
        private static IEnumerable<Artical> artical;

        public static void UserDealing()
        {
            Console.WriteLine($"Welcome {ProjectDetails.ProjectName}\n" +
                $"{ProjectDetails.ProjectVersion}\n" +
                $"{ProjectDetails.ProjectDescription}\n\n");
            SeedDate();
            Console.WriteLine("Are you current user? true or false");
            bool IsCurrent = Convert.ToBoolean(Console.ReadLine());
            User user = new User();
            if (IsCurrent)
            {
                user = LoginForm();
                if (user.userRole.Name == Admin.AdminRole)
                {
                    AdminUserDealing(user);
                }
                else
                {
                    GeneralUserDealing(user);
                }
            }
            else
            {
                user = RegisterUser();
            }

        }


        private static void SeedDate()
        {
            UserService userService = new UserService();
            User user = new User();
            UserRoleService userRoleService = new UserRoleService();

            UserRole AdminRole = new UserRole();
            AdminRole.Name = Admin.AdminRole;
            userRoleService.Add(AdminRole);

            UserRole GeneralRole = new UserRole();
            GeneralRole.Name = "GeneralUser";
            userRoleService.Add(GeneralRole);

            if (!userService.IsExist(Admin.AdminName, Admin.AdminPassword))
            {
                user.UserName = Admin.AdminName;
                user.FirstName = Admin.AdminName;
                user.LastName = Admin.AdminName;
                user.Password = Admin.AdminPassword;
                user.ConfirmPassword = Admin.AdminPassword;
                user.UserRoleId = 1;
                userService.Add(user);
            }
        }

        private static User RegisterUser()
        {
            UserService userService = new UserService();
            User user = new User();
            for (; ; )
            {
                Console.WriteLine("please full register form\n");

                Console.WriteLine("Insert your first name");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("Insert your last name");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Insert your username");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Insert your password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Please Confirm password");
                user.ConfirmPassword = Console.ReadLine();
                user.UserRoleId = 2;

                userService.Add(user);
                user = userService.LogIn(user.UserName, user.Password);
                if (user == null)
                {
                    Console.WriteLine("Some thing is wrong please try again");
                }
                else
                {
                    Console.WriteLine($"you has been registered successfuly {user.FullName}");
                    break;
                }
            }
            return user;
        }
        private static void AdminUserDealing(User user)
        {

            Console.WriteLine($"Wellcome {user.FullName}!");
            for (; ; )
            {
                Console.WriteLine("Please choose number of action\n-----\n" +
                    "1.Display all articals\n" +
                    "2.Add new article\n" +
                    "3.Desactive Article\n" +
                    "4.Add main category\n" +
                    "5.Display all categories\n" +
                    "6.Desactive category\n" +
                    "7.get articals by auther\n" +
                    "8.Close actions");
                // add get article by auther + add category 
                int Action = Convert.ToInt16(Console.ReadLine());

                switch (Action)
                {
                    case 1:
                        GetAllArticals();
                        break;
                    case 2:
                        AddArtical();
                        break;
                    case 3:
                        DectiveArtical();
                        break;
                    case 4:
                        AddMainCategorey();
                        break;
                    case 5:
                        GetAllMainCategoryes();
                        break;
                    case 6:
                        DectiveMainCategorey();
                        break;
                    case 7:
                        break;
                }
                if (Action == 8)
                {
                    break;
                }
            }
        }
        private static void GeneralUserDealing(User user)
        {
            for (; ; )
            {
                if (user == null)
                {

                }
                else
                {
                    Console.WriteLine($"Hello {user.FullName}\n");
                    Console.WriteLine("Please insert number of action\n" +
                        "1.View Profile \n" +
                        "2.Update profile \n" +
                        "3.Display articles by category\n" +
                        "4.Close actions");
                    int ActionNumber = Convert.ToInt32(Console.ReadLine());
                    switch (ActionNumber)
                    {
                        case 1:
                            ViewProfile(user);
                            break;
                        case 2:
                            UpdateProfile(user);
                            break;
                        default:
                            break;
                        case 3:
                            GetAllMainCategoryes();
                            break;
                    }
                    if (ActionNumber == 4)
                    {
                        break;
                    }
                }
            }
        }
        private static User LoginForm()
        {
            UserService userService = new UserService();
            User user;
            Console.WriteLine("Insert your username");
            string Username = Console.ReadLine();
            Console.WriteLine("Insert your password");
            string Password = Console.ReadLine();

            user = userService.LogIn(Username, Password);
            return user;
        }
        private static void ViewProfile(User user)
        {
            Console.WriteLine($"first name {user.FirstName}\n" +
                $"last name {user.LastName}\n" +
                $"user name {user.UserName}");
        }
        private static void UpdateProfile(User user)
        {
            ViewProfile(user);
        }
        private static void GetAllArticals()
        {
            ArticalService articalService = new ArticalService();
            List<Artical> articals = articalService.GetAll();
            Console.WriteLine("All artical\n_______________\n");
            foreach (Artical artical in artical)
            {
                DisplayArtical(artical, true);
            }
        }
        private static void DisplayArtical(Artical artical, bool IsAdmin = false)
        {
            if (IsAdmin)
            {
                Console.WriteLine($"id is.{artical.Id}");// title + body + auther id + created date
                Console.WriteLine($"artical name is.{artical.Name}" );
                Console.WriteLine($"body is.{artical.Body}");
                Console.WriteLine($"auther id is.{artical.AutherId}");
                Console.WriteLine($"created date is.{artical.CreatedDate}");
            }
            else
            {
                //title + body 
                Console.WriteLine($"artical name is.{artical.Name}");
                Console.WriteLine($"body is.{artical.Body}");
            }
        }
        private static void AddArtical()
        {
            Artical artical = ArticalForm();
            ArticalService articalService = new ArticalService();
            articalService.Add(artical);
        }
        private static Artical ArticalForm()
        {
            Artical artical = new Artical();
            Console.WriteLine("Isert name of artical");
            artical.ArticalName = Console.ReadLine();
            Console.WriteLine("Isert body");
            artical.Body = Console.ReadLine();
            return artical;
        }
        private static void DectiveArtical()
        {
            Console.WriteLine("Insert artical id ");
            int id = Convert.ToInt16(Console.ReadLine());
            IArtical articalService = new ArticalService();
            articalService.Dective(id);
        }
        private static void AddMainCategorey()
        {
            MainCategorey mainCategorey = MainCategoreyForm();
            MainCategoreyService articalService = new MainCategoreyService();
            articalService.Add(mainCategorey);
        }
        private static MainCategorey MainCategoreyForm()
        {
            MainCategorey mainCategorey = new MainCategorey();
            Console.WriteLine("Isert name of main categorey");
            mainCategorey.Name = Console.ReadLine();
            return mainCategorey;

        }
        private static void GetAllMainCategoryes()
        {
            MainCategoreyService mainCategoreyService = new MainCategoreyService();
            List<MainCategorey> mainCategoreys = mainCategoreyService.Get();
            Console.WriteLine("All main category\n_______________\n");
            foreach (MainCategorey mainCategorey in mainCategoreys)
            {
                DisplayMainCategorey(mainCategorey, true);
            }
        }
        private static void DisplayMainCategorey(MainCategorey mainCategorey, bool IsAdmin = false)
        {
            if (IsAdmin)
            {
                Console.WriteLine($"id is.{mainCategorey.Id}");
                Console.WriteLine($"artical name is.{mainCategorey.Name}");
            }
            else
            {
           
            }
        }
        private static void DectiveMainCategorey()
        {
            Console.WriteLine("Insert main categorey id ");
            int id = Convert.ToInt16(Console.ReadLine());
            IMainCategory MainCategoreyService = new MainCategoreyService();
            MainCategoreyService.Dective(id);
        }
    }
}
