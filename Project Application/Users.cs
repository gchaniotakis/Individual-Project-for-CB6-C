using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Project_Application
{
    enum UserRank { SuperAdmin, SuperUser, DataEditor, DataViewer };
    class Users
    {


        public class User
        {
            public static string Username;
            public UserRank Rank;
        }

        internal class DataViewer : User
        {


            public DataViewer(string username, UserRank role)
            {
                Username = username;
                Rank = role;
            }

            public static void ChangePassword()
            {
                string password1;
                string password2;

                do
                {
                    Console.WriteLine("Pick a password");
                    password1 = Console.ReadLine();

                    Console.WriteLine("Enter your password a second time");
                    password2 = Console.ReadLine();

                    if (password1 != password2)
                    {
                        Console.WriteLine("Passwords don't match");
                    }

                } while (password1 != password2);

                Database_Access.PasswordChange(password1, Username);
            }







            public static void SendMessage(string receiver)
            {


                Console.WriteLine("Type your message, limit 250 characters.");
                string content = Console.ReadLine();
                int sentid = Database_Access.MessageSend(Username, receiver, content);
                Console.Clear();
                ViewHistory(receiver);
                Message messagetosend = Database_Access.Sentid(sentid);
                File_Acess.NewMessage(messagetosend);


            }


            public static void ViewHistory(string receiver)
            {

                var history = Database_Access.GetHistory(Username, receiver);



                foreach (var h in history)
                {
                    Console.WriteLine($"MessageID: {h.MessageId}");
                    Console.WriteLine($"From:{h.Sender}");
                    Console.WriteLine($"To:{h.Receiver}, at: {h.Datetime}");
                    Console.WriteLine($"{h.Content}");
                    Console.WriteLine("--------------------------------------");

                }

            }
        }

        internal class DataEditor : DataViewer
        {

            string connectionString = Properties.Settings.Default.connectionstring;

            public DataEditor(string Name, UserRank Role) : base(Name, UserRank.DataEditor)
            {

            }

            public void EditMessage(int messageid, string receiver)
            {
                string Sender = Username;
                string Receiver = receiver;
                int idtoselect = messageid;

                bool check = Database_Access.SenderCheck(Username, idtoselect);

                if (check == true)
                {
                    Console.WriteLine("Type your new message, limit 250 characters.");
                    string newcontent = Console.ReadLine();
                    Database_Access.EditMessage(newcontent, Sender, Receiver, idtoselect);
                    Console.Clear();
                    Console.WriteLine("Message editing complete!");
                    ViewHistory(receiver);
                    Message messagetoedit = Database_Access.IdRetrieve(idtoselect);
                    File_Acess.EditMessage(messagetoedit);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You can't edit message you haven't sent.");
                }

            }
        }

        internal class SuperUser : DataEditor
        {


            public SuperUser(string Name, UserRank Role) : base(Name, UserRank.SuperUser)
            {

            }

            public void DeleteMessage(int messageid, string receiver)
            {
                string Sender = Username;
                string Receiver = receiver;
                int idtoselect = messageid;
                bool check = Database_Access.SenderCheck(Sender, idtoselect);
                if (check == true)
                {
                    Database_Access.MessageDeletion(Sender, Receiver, idtoselect);
                    Console.Clear();
                    Console.WriteLine("Message deletion complete!");
                    ViewHistory(receiver);
                    Message messagetodelete = Database_Access.IdRetrieve(idtoselect);
                    File_Acess.DeleteMessage(messagetodelete);
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("You can't delete messages you haven't sent.");
                }




            }
        }

        internal class SuperAdmin : SuperUser
        {


            public SuperAdmin(string Name, UserRank Role) : base(Name, UserRank.SuperAdmin)
            {

            }

            public void CreateUser()
            {
                bool NameOriginal = false;
                string Name = "";

                while (NameOriginal == false)
                {
                    Console.WriteLine("Pick a username:");
                    Name = Console.ReadLine();

                    NameOriginal = Database_Access.NameCheck(Name);

                    if (NameOriginal == false)
                    {
                        Console.WriteLine("This username is already in use! Please pick another one.");

                    }

                }

                string Pass1 = "0000";

                Database_Access.UserCreation(Name, Pass1);
                Console.Clear();
                ListUsers();
            }

            public void DemoteUser(string user)
            {

                string Rank = Database_Access.RankCheck(user);
                string NewRank = "";

                if (Rank == "SuperAdmin")
                {
                    NewRank = NewRank + "SuperUser";
                }
                else if (Rank == "Superuser")
                {
                    NewRank = NewRank + "DataEditor";
                }
                else if (Rank == "DataEditor")
                {
                    NewRank = NewRank + "DataViewer";
                }
                else
                {
                    Console.WriteLine($"{user} cannot be demoted further!");
                    return;
                }

                Database_Access.Demotion(NewRank, user);
                Console.WriteLine($"{user} has been demoted to {NewRank}!");
                ListUsers();
            }

            public void DeleteUser(string user)
            {

                Database_Access.UserDeletion(user);
                Console.WriteLine($"{user} has been deleted!");
                ListUsers();
            }

            public void PromoteUser(string user)
            {

                string Rank = Database_Access.RankCheck(user);


                string NewRank = "";

                if (Rank == "DataViewer")
                {
                    NewRank = NewRank + "DataEditor";
                }
                else if (Rank == "DataEditor")
                {
                    NewRank = NewRank + "SuperUser";
                }
                else if (Rank == "SuperUser")
                {
                    NewRank = NewRank + "SuperAdmin";
                }
                else
                {
                    Console.WriteLine($"{user} cannot be promoted further!");
                    return;
                }

                Database_Access.Promotion(NewRank, user);
                Console.WriteLine($"{user} has been promoted to {NewRank}!");
                ListUsers();
            }



            public void ListUsers()
            {

                var Userlist = Database_Access.Userlist();


                foreach (var user in Userlist)
                {
                    Console.WriteLine(Username + " - " + user.Rank);
                }
            }







        }

        public class Message
        {

            public int MessageId { get; set; }
            public string Sender { get; set; }
            public string Receiver { get; set; }
            public DateTime Datetime { get; set; }
            public string Content { get; set; }



        }
    }
}


