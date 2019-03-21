using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Project_Application
{
    class Database_Access
    {
        static string connectionString = Properties.Settings.Default.connectionstring;

        static internal void PasswordChange(string pass1, string username)
        {


            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var passwordchange = dbcon.Query("UPDATE Users SET password=@password WHERE username=@username;", new { password = pass1, username = username });

            }
            Console.WriteLine("Your password has been successfully updated.");

        }

        static internal int MessageSend(string Sender, string Receiver, string Content)
        {
            string queryMessage = "INSERT INTO Messages (date, sender, receiver, content) VALUES (@date, @sender, @receiver, @content);";
            string getsentid = "SELECT messageid FROM Messages WHERE content = @content AND date = @date;";
            DateTime date = DateTime.UtcNow;
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                var sendMessage = dbcon.Query(queryMessage, new { date = date, sender = Sender, receiver = Receiver, content = Content });
                return dbcon.Query<int>(getsentid, new { content = Content, date = date }).Single();
            }
        }


        static internal List<Users.Message> GetHistory(string Username, string User2)
        {
            var messages = new List<Users.Message>();
            string historyQuery = "SELECT * FROM Messages WHERE((sender = @Sender AND receiver = @Receiver) OR (sender = @Receiver AND receiver = @Sender)) ORDER BY date;";
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();

                messages.AddRange(dbcon.Query<Users.Message>(historyQuery, new { Sender = Username, Receiver = User2 }));

            }
            return messages;
        }




        static internal void EditMessage(string text, string sender, string receiver, int messageid)
        {
            string Query = "UPDATE Messages SET content = @content WHERE (sender = @sender AND receiver = @receiver  AND messageid = @messageid);";
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var alterMessage = dbcon.Query(Query, new { content = text, sender = sender, receiver = receiver, messageid = messageid });
            }
        }

        static internal void MessageDeletion(string sender, string receiver, int messageid)
        {
            string Query = "DELETE FROM Messages WHERE (sender = @sender AND receiver = @receiver  AND messageid = @messageid);";
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var deleteMessage = dbcon.Query(Query, new { sender = sender, receiver = receiver, messageid = messageid });
            }
        }

        static internal string RankCheck(string User2)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            string rank;
            using (dbcon)
            {
                dbcon.Open();

                rank = dbcon.Query<string>("SELECT rank FROM Users WHERE username = @username", new { username = User2 }).Single();
            }
            return rank;
        }

        static internal void Demotion(string newrank, string User2)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();

                var Demotion = dbcon.Query("UPDATE Users SET rank = @newrank WHERE username = @name", new { newrank = newrank, name = User2 });
            }
        }

        static internal void Promotion(string newrank, string User2)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();

                var promotion = dbcon.Query("UPDATE Users SET rank = @newrank WHERE username = @username", new { newrank = newrank, username = User2 });
            }
        }




        static internal List<Users.User> Userlist()
        {
            string list = "SELECT * FROM Users;";
            var users = new List<Users.User>();
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                users.AddRange(dbcon.Query<Users.User>(list));
            }
            return users;
        }

        static internal void UserDeletion(string User2)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            string usernameQuery = "DELETE FROM Users WHERE username = @username;";
            string messageQuery = "DELETE FROM Messages WHERE (sender = @username OR receiver = @username);";

            using (dbcon)
            {
                dbcon.Open();
                var deleteHistory = dbcon.Query(messageQuery, new { user = User2 });
                var deleteUser = dbcon.Query(usernameQuery, new { user = User2 });
            }
        }

        static internal bool NameCheck(string Name)
        {
            bool nameOriginal;
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var usernameCheck = dbcon.Query("SELECT * FROM Users WHERE username = @username;", new { username = Name }).Count();

                if (usernameCheck == 1)
                {
                    nameOriginal = false;
                }
                else
                {
                    nameOriginal = true;
                }

                return nameOriginal;
            }
        }

        static internal void UserCreation(string Name, string Pass1)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();

                string creationQuery = "INSERT INTO Users (username,password,rank) VALUES (@username,@password, @rank);";
                var accountInsertion = dbcon.Query(creationQuery, new { name = Name, password = Pass1, rank = "DataViewer" });

            }
            Console.WriteLine($"The user {Name} has been created.");

        }

        static internal bool PasswordCheck(string Username)
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                while (true)
                {
                    Console.WriteLine("Please input your Password:");
                    string password = Console.ReadLine();
                    var paperCheck = dbcon.Query("SELECT * FROM Users WHERE username = @username AND password =@password", new { username = Username, password = password }).Count();

                    if (paperCheck == 1)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Password is incorrect!");
                        Console.WriteLine("Access Denied!");
                    }
                }

            }

        }

        static internal bool SenderCheck(string Username, int messageid)
        {
            string Query = "SELECT * FROM Messages WHERE ( sender = @sender AND messageid = @messageid);";
            SqlConnection dbcon = new SqlConnection(connectionString);
            int match;

            using (dbcon)
            {
                match = dbcon.Query(Query, new { sender = Username, messageid = messageid }).Count();
            }

            if (match == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static internal Users.Message IdRetrieve(int messageid)
        {
            string LastIdGet = "SELECT * FROM Messages WHERE messageid = @messageid;";
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                return dbcon.Query<Users.Message>(LastIdGet, new { messageid = messageid }).First();
            }
        }

        static internal Users.Message Sentid(int messageid)
        {
            string LastIdGet = "SELECT * FROM Messages WHERE messageid = @messageid;";
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                return dbcon.Query<Users.Message>(LastIdGet, new { messageid = messageid }).First();
            }
        }

    }
}



