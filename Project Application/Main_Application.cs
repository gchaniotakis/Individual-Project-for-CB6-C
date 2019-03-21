using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using static Project_Application.Login_Screen;
using static Project_Application.Users;
using static Project_Application.Menus;
namespace Project_Application
{
    class Main_Application
    {
        static void Main(string[] args)
        {
            while (true)
            {
                LoginMenu NewMenu = new LoginMenu();
                User User = NewMenu.LoginScreen();


                if (User.Rank == UserRank.SuperAdmin)
                {
                    SuperAdmin User1 = new SuperAdmin(User.Username, UserRank.SuperAdmin);
                    Menus NewMenu1 = new Menus();
                    NewMenu1.SuperAdminMenu(User1);
                }
                else if (User.Rank == UserRank.SuperUser)
                {
                    SuperUser User1 = new SuperUser(User.Username, UserRank.SuperUser);
                    Menus NewMenu2 = new Menus();
                    NewMenu2.SuperUserMenu(User1);
                }
                else if (User.Rank == UserRank.DataEditor)
                {
                    DataEditor User1 = new DataEditor(User.Username, UserRank.DataEditor);
                    Menus NewMenu3 = new Menus();
                    NewMenu3.DataEditorMenu(User1);
                }
                else
                {
                    DataViewer User1 = new DataViewer(User.Username, UserRank.DataViewer);
                    Menus NewMenu4 = new Menus();
                    NewMenu4.DataViewerMenu(User1);
                }
            }
        }
    }
}
