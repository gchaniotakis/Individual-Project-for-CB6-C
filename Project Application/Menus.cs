using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using static Project_Application.Users;
using static Project_Application.Login_Screen.LoginMenu;

namespace Project_Application
{
    class Menus
    {
        internal void DataViewerMenu(DataViewer user)
        {
            bool InUse = true;
            Console.Clear();
            Console.WriteLine($"Welcome back, {User.Username}");
            while (InUse == true)
            {

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("V- View messages and interact with and interact with another user");
                Console.WriteLine("C - Change password");
                Console.WriteLine("L - Logout");

                string Selection = Console.ReadLine();

                switch (Selection.ToLower())
                {
                    case "v":
                        Console.Clear();
                        Console.WriteLine("Enter a username or type r to return to the Main Menu:");

                        string user2 = Console.ReadLine();

                        if (user2.ToLower() == "r")
                        {
                            break;
                        }
                        bool UserInSystem = true;

                        while (UserInSystem == true)
                        {
                            UserInSystem = Database_Access.NameCheck(user2);
                            if (UserInSystem == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"The username {user2} cannot be found!");
                                Console.WriteLine("Please enter a valid username:");
                                user2 = Console.ReadLine();
                            }
                        }


                        DataViewer.ViewHistory(user2);
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("S - Send message");
                        Console.WriteLine("R - Return to the previous screen");
                        string ActionSelection = Console.ReadLine();

                        switch (ActionSelection.ToLower())
                        {
                            case "r":
                                Console.Clear();
                                break;
                            case "s":
                                DataViewer.SendMessage(user2);
                                break;
                            default:
                                Console.WriteLine("Please use one of the available actions.");
                                break;
                        }
                        break;
                    case "c":
                        Console.Clear();
                        DataViewer.ChangePassword();
                        break;
                    case "l":
                        Console.Clear();
                        InUse = false;
                        Console.WriteLine("You were successfully logged out");
                        break;
                    default:
                        Console.WriteLine("Please use one of the available actions.");
                        break;
                }
            }
        }

        internal void DataEditorMenu(DataEditor User)
        {
            bool InUse = true;
            Console.Clear();
            Console.WriteLine($"Welcome back, {Users.User.Username}");
            while (InUse == true)
            {

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("V - View messages");
                Console.WriteLine("C - Change password");
                Console.WriteLine("L - Logout");
                string Selection = Console.ReadLine();

                switch (Selection.ToLower())
                {
                    case "v":
                        Console.Clear();
                        Console.WriteLine("Enter a username or type r to return to the Main Menu:");

                        string User2 = Console.ReadLine();

                        if (User2.ToLower() == "r")
                        {
                            break;
                        }
                        bool UserInSystem = true;

                        while (UserInSystem == true)
                        {
                            UserInSystem = Database_Access.NameCheck(User2);
                            if (UserInSystem == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"The user {User2} cannot be found!");
                                Console.WriteLine("Please enter a valid username:");
                                User2 = Console.ReadLine();
                            }
                        }
                        DataViewer.ViewHistory(User2);
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("S - Send message");
                        Console.WriteLine("E - Edit message");
                        Console.WriteLine("R - Return to the previous screen");
                        string ActionSelection = Console.ReadLine();

                        switch (ActionSelection.ToLower())
                        {
                            case "r":
                                Console.Clear();
                                break;
                            case "s":
                                DataViewer.SendMessage(User2);
                                break;
                            case "e":
                                Console.WriteLine("Select the message ID you want to edit:");
                                int messageeditid = int.Parse(Console.ReadLine());
                                User.EditMessage(messageeditid, User2);
                                break;
                            default:
                                Console.WriteLine("Please use one of the available actions.");
                                break;
                        }
                        break;
                    case "c":
                        Console.Clear();
                        DataViewer.ChangePassword();
                        break;
                    case "l":
                        Console.Clear();
                        InUse = false;
                        Console.WriteLine("You were successfully logged out.");
                        break;
                    default:
                        Console.WriteLine("Please use one of the available actions.");
                        break;
                }
            }
        }
        internal void SuperUserMenu(SuperUser User)
        {
            bool InUse = true;
            Console.Clear();
            Console.WriteLine($"Welcome back, {Users.User.Username}");
            while (InUse == true)
            {

                Console.WriteLine("What do you want to do?");
                Console.WriteLine("V - View messages");
                Console.WriteLine("C - Change password");
                Console.WriteLine("L - Logout");
                string Selection = Console.ReadLine();

                switch (Selection.ToLower())
                {
                    case "v":
                        Console.Clear();
                        Console.WriteLine("Enter a username or type r to return to the Main Menu:");

                        string User2 = Console.ReadLine();

                        if (User2.ToLower() == "r")
                        {
                            break;
                        }
                        bool UserInSystem = true;

                        while (UserInSystem == true)
                        {
                            UserInSystem = Database_Access.NameCheck(User2);
                            if (UserInSystem == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"The user {User2} cannot be found!");
                                Console.WriteLine("Please enter a valid username:");
                                User2 = Console.ReadLine();
                            }
                        }
                        DataViewer.ViewHistory(User2);
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("S - Send message");
                        Console.WriteLine("E - Edit message");
                        Console.WriteLine("D - Delete message");
                        Console.WriteLine("R - Return to the previous screen");
                        string ActionSelection = Console.ReadLine();

                        switch (ActionSelection.ToLower())
                        {
                            case "r":
                                Console.Clear();
                                break;
                            case "s":
                                DataViewer.SendMessage(User2);
                                break;
                            case "e":
                                Console.WriteLine("Select the message ID you want to edit:");
                                int messageeditid = int.Parse(Console.ReadLine());
                                User.EditMessage(messageeditid, User2);
                                break;
                            case "d":
                                Console.WriteLine("Copy and Paste the message ID of the message you want to delete:");
                                int messagedeleteid = int.Parse(Console.ReadLine());
                                User.DeleteMessage(messagedeleteid, User2);
                                break;
                            default:
                                Console.WriteLine("Please use one of the available actions.");
                                break;
                        }
                        break;
                    case "c":
                        Console.Clear();
                        DataViewer.ChangePassword();
                        break;
                    case "l":
                        Console.Clear();
                        InUse = false;
                        Console.WriteLine("You have been successfully logged out");
                        break;
                    default:
                        Console.WriteLine("Please use one of the available actions.");
                        break;
                }
            }
        }

        internal void SuperAdminMenu(SuperAdmin SuperAdmin)
        {
            bool InUse = true;
            Console.Clear();
            Console.WriteLine($"Welcome back, {User.Username}");
            while (InUse == true)
            {


                Console.WriteLine("What do you want to do?");
                Console.WriteLine("V - View messages");
                Console.WriteLine("A - Admininstratrion menu");
                Console.WriteLine("C - Change password");
                Console.WriteLine("L - Logout");
                string Selection = Console.ReadLine();

                switch (Selection.ToLower())
                {
                    case "v":
                        Console.Clear();
                        Console.WriteLine("Enter a username or type r to go back to the Main Menu:");


                        string User2 = Console.ReadLine();

                        if (User2.ToLower() == "r")
                        {
                            break;
                        }
                        bool UserOtherInSystem = true;

                        while (UserOtherInSystem == true)
                        {
                            UserOtherInSystem = Database_Access.NameCheck(User2);
                            if (UserOtherInSystem == true)
                            {
                                Console.Clear();
                                Console.WriteLine($"The user {User2} cannot be found!");
                                Console.WriteLine("Please enter a valid username:");
                                User2 = Console.ReadLine();
                            }
                        }
                        DataViewer.ViewHistory(User2);
                        Console.WriteLine("Choose action:");
                        Console.WriteLine("S - Send message");
                        Console.WriteLine("E - Edit message");
                        Console.WriteLine("D - Delete message");
                        Console.WriteLine("R - Return to the previous screen");
                        string ActionSelection = Console.ReadLine();

                        switch (ActionSelection.ToLower())
                        {
                            case "r":
                                Console.Clear();
                                break;
                            case "s":
                                DataViewer.SendMessage(User2);
                                break;
                            case "e":
                                Console.WriteLine("Select the message ID you want to edit:");
                                int messageeditid = int.Parse(Console.ReadLine());
                                SuperAdmin.EditMessage(messageeditid, User2);
                                break;
                            case "d":
                                Console.WriteLine("Copy and Paste the message ID of the message you want to delete:");
                                int messagedeleteid = int.Parse(Console.ReadLine());
                                SuperAdmin.DeleteMessage(messagedeleteid, User2);
                                break;
                            default:
                                Console.WriteLine("Please use one of the available actions.");
                                break;
                        }
                        break;
                    case "a":
                        Console.Clear();
                        Console.WriteLine("L - List of registered users");
                        Console.WriteLine("R - Return to the Main Menu");
                        string AdminSelection = Console.ReadLine();

                        switch (AdminSelection.ToLower())
                        {
                            case "r":
                                break;
                            case "l":
                                Console.Clear();
                                SuperAdmin.ListUsers();
                                Console.WriteLine("Choose action:");
                                Console.WriteLine("C - Create a new user");
                                Console.WriteLine("P - Promote an existing user");
                                Console.WriteLine("D - Demote an existing user");
                                Console.WriteLine("E - Erase an existing user's account");
                                Console.WriteLine("R - Return to Previous Screen");
                                string SuperUserSelection = Console.ReadLine();
                                string UserOther = "";
                                bool UserInList = true;
                                switch (SuperUserSelection.ToLower())
                                {
                                    case "r":
                                        Console.Clear();
                                        break;
                                    case "c":
                                        SuperAdmin.CreateUser();
                                        break;

                                    case "p":
                                        Console.WriteLine("Please pick a user from the list:");
                                        UserOther = Console.ReadLine();
                                        while (UserInList == true)
                                        {
                                            UserInList = Database_Access.NameCheck(UserOther);
                                            if (UserInList == true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"The username {UserOther} cannot be found!");
                                                Console.WriteLine("Please enter a valid username:");
                                                User2 = Console.ReadLine();
                                            }
                                        }
                                        SuperAdmin.PromoteUser(UserOther);
                                        break;
                                    case "d":
                                        Console.WriteLine("Please pick a user from the list:");
                                        UserOther = Console.ReadLine();
                                        while (UserInList == true)
                                        {
                                            UserInList = Database_Access.NameCheck(UserOther);
                                            if (UserInList == true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"The username {UserOther} cannot be found!");
                                                Console.WriteLine("Please enter a valid username:");
                                                User2 = Console.ReadLine();
                                            }
                                        }
                                        SuperAdmin.DemoteUser(UserOther);
                                        break;
                                    case "e":
                                        Console.WriteLine("Please pick a user from the list:");
                                        UserOther = Console.ReadLine();
                                        while (UserInList == true)
                                        {
                                            UserInList = Database_Access.NameCheck(UserOther);
                                            if (UserInList == true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine($"The username {UserOther} cannot be found!");
                                                Console.WriteLine("Please enter a valid username:");
                                                User2 = Console.ReadLine();
                                            }
                                        }
                                        Console.Clear();
                                        string SecurityCheck = "";
                                        while (SecurityCheck.ToLower() != "y" && SecurityCheck.ToLower() != "n")
                                        {
                                            Console.WriteLine($"The user {UserOther} will be PERMANENTLY DELETED");
                                            Console.WriteLine("as will all the messages they have sent or received!");
                                            Console.WriteLine("ARE YOU SURE?");
                                            Console.WriteLine("[ Y / N]");
                                            SecurityCheck = Console.ReadLine();
                                        }
                                        if (SecurityCheck.ToLower() != "y")
                                        {
                                            SuperAdmin.DeleteUser(UserOther);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Please use one of the available actions.");
                                        break;
                                }
                                break;
                            default:
                                Console.WriteLine("Please use one of the available actions.");
                                break;
                        }
                        break;
                    case "c":
                        Console.Clear();
                        DataViewer.ChangePassword();
                        break;
                    case "l":
                        Console.Clear();
                        InUse = false;
                        Console.WriteLine("You have been successfully logged out.");
                        break;
                    default:
                        Console.WriteLine("Please use one of the available actions.");
                        break;

                }
            }
        }
    }
}


