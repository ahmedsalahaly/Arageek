using Arageek.Consts;
using Arageek.Models;
using Arageek.Models.Users;
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
        public static void UserDealing()
        {
            Console.WriteLine($"Welcome {ProjectDetails.ProjectName}\n" +
                $"{ProjectDetails.ProjectVersion}\n" +
                $"{ProjectDetails.ProjectDescription}\n\n");
            SeedDate();
            Console.WriteLine("Are you current user? true or false");
            bool IsCurrent = Convert.ToBoolean(Console.ReadLine());
            User user = new User();
            
        }

        private static void SeedDate()
        {
            UserService userService = new UserService();

            User user = new User();
            UserRoleService userRoleService = new UserRoleService();

            UserRole UserAdmin = new UserRole();
            UserAdmin.Name = Admin.AdminRole;
            userRoleService.Add(UserAdmin);

            UserRole GeneralUser = new UserRole();
            GeneralUser.Name = "GeneralUser";
            userRoleService.Add(GeneralUser);

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
                Console.WriteLine("please fill register form\n");

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
                    Console.WriteLine($"you has been registered successfuly{user.FullName}");
                    break;
                }
            }
            return user;
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
                       "2.Update profile \n " +
                        "3.Close actions");
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
                    }
                    if (ActionNumber == 3)
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
    }
}
