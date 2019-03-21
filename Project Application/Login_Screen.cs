using System;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using static Project_Application.Users;


namespace Project_Application
{
    class Login_Screen
    {
        internal class LoginMenu
        {
            static string connectionString = Properties.Settings.Default.connectionstring;
            internal DataViewer LoginScreen()
            {
                while (true)
                {
                    Console.WriteLine("Welcome to the Messenger app. ");





                    SqlConnection dbcon = new SqlConnection(connectionString);



                    bool UserInBase = true;
                    string Username = "";

                    while (UserInBase == true)
                    {
                        Console.WriteLine("Please input your Username:");
                        Username = Console.ReadLine();

                        UserInBase = Database_Access.NameCheck(Username);

                        if (UserInBase == true)
                        {
                            Console.WriteLine($"The user {Username} does not exist!");
                        }

                    }

                    Database_Access.PasswordCheck(Username);
                    using (dbcon)
                    {
                        dbcon.Open();

                        var AuthorityCheck = dbcon.Query<string>("SELECT rank FROM Users WHERE username = @username;", new { username = Username }).Single();

                        if (AuthorityCheck == "DataViewer")
                        {
                            return new DataViewer(Username, UserRank.DataViewer);
                        }
                        else if (AuthorityCheck == "DataEditor")
                        {
                            return new DataEditor(Username, UserRank.DataEditor);
                        }
                        else if (AuthorityCheck == "SuperUser")
                        {
                            return new SuperUser(Username, UserRank.SuperUser);
                        }
                        else if (AuthorityCheck == "SuperAdmin")
                        {
                            return new SuperAdmin(Username, UserRank.SuperAdmin);
                        }
                    }

                }

            }

        }









    }
}

